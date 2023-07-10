using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WCLibrary.Modeli;

namespace WCLibrary
{
    public class WCPodaci
    {
        private static string Direktorij = "../../../WindowsFormsApp/bin/debug/";

        public static async Task<List<Team>> DohvatiTimove(string spol)
        {
            string url = "";
            
            if (spol == "MEN")
            {
                url = "https://worldcup-vua.nullbit.hr/men/teams";
            }
            else 
            {
                url = "https://worldcup-vua.nullbit.hr/women/teams";
            }

            var restKlijent = new RestClient(url);

            var rezultat = await restKlijent.ExecuteGetAsync<List<Team>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Team>>(rezultat.Content);
        }

        public static async Task<List<Player>> DohvatiIgrace(string spol, string fifaCode)
        {
            var datoteka = $"../../../WindowsFormsApp/bin/debug/{spol}_{fifaCode}.json";
            List<Player> igraci = new List<Player>();
            List<TeamEvent> dogadjaji = new List<TeamEvent>();

            if (WCPostavke.DatotekaPostoji(datoteka))
            {
                using (StreamReader citac = new StreamReader(datoteka))
                {
                    var json = citac.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Player>>(json);
                }
            }
            else
            {
                var utakmice = await DohvatiUtakmice(spol, fifaCode);

                if (utakmice[0].HomeTeam.Code == fifaCode)
                {
                    igraci = utakmice[0].HomeTeamStatistics.StartingEleven;
                    igraci.AddRange(utakmice[0].HomeTeamStatistics.Substitutes);
                }
                else
                {
                    igraci = utakmice[0].AwayTeamStatistics.StartingEleven;
                    igraci.AddRange(utakmice[0].AwayTeamStatistics.Substitutes);
                }


                //  TeamEvents

                foreach (var utakmica in utakmice)
                {
                    if (utakmica.HomeTeam.Code == fifaCode)
                    {
                        dogadjaji.AddRange(utakmica.HomeTeamEvents.ToList());
                    }
                    else
                    {
                        dogadjaji.AddRange(utakmica.AwayTeamEvents.ToList());
                    }
                }

                foreach (var igrac in igraci)
                {
                    igrac.ZabijeniGolovi = VratiGolove(dogadjaji, igrac.Name);
                    igrac.ZutiKartoni = VratiZuteKartone(dogadjaji, igrac.Name);
                }


                return igraci;
            }
        }

        public static async Task<List<Match>> DohvatiUtakmice(string spol, string fifaCode)
        {
            string url;
            if (spol == "MEN")
            {
                url = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
            }
            else
            {
                url = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
            }

            var restKlijent = new RestClient(url + fifaCode);

            var rezultat = await restKlijent.ExecuteGetAsync<List<Match>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Match>>(rezultat.Content);

        }

        private static int VratiGolove(List<TeamEvent> teamsdogadjaji, string igrac)
        {
            return teamsdogadjaji.Where(i => i.Player == igrac && i.TypeOfEvent == "goal").Count();
        }

        private static int VratiZuteKartone(List<TeamEvent> teamsdogadjaji, string igrac)
        {
            return teamsdogadjaji.Where(i => i.Player == igrac && i.TypeOfEvent == "yellow-card").Count();
        }

        public static void SpremiPodatkeForme(List<Player> igraci, string spol, string fifaCode)
        {
            var podaci = JsonConvert.SerializeObject(igraci);

            var datoteka = Direktorij + $"{spol}_{fifaCode}.json";

            File.WriteAllText(datoteka, podaci);
        }

        public enum TipTima
        {
            Muski, Zenski
        }

        public enum Rezolucija
        {
            Full_Screen, Mala, Srednja, Velika, NemaRezolucije
        }
        public enum Jezici
        {
            Hrvatski, Engleski
        }

    }
}
