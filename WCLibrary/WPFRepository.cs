using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCLibrary.Modeli;
using static WCLibrary.WCPodaci;

namespace WCLibrary
{
    public class WPFRepository
    {
        private static string PostavkeFile = "../../../WindowsFormsApp/bin/debug/postavke.txt";
        public static void SpremanjePodatakaTima(List<Player> Igraci, TipTima tipTima, string FifaCode)
        {
            using (StreamWriter pisanje = new StreamWriter(DovacanjeTipaTima(tipTima, FifaCode)))
            {
                foreach (Player igrac in Igraci)
                {
                    pisanje.Write(igrac.ToString());
                    pisanje.Write(Environment.NewLine);
                }
            }
        }
        public static List<Player> DohvatiPodatkeTima(TipTima tipTima, string FifaCode)
        {

            string NazivFilea = DovacanjeTipaTima(tipTima, FifaCode);
            if (!File.Exists(NazivFilea))
                return null;

            using (StreamReader citanje = new StreamReader(NazivFilea))
            {
                List<Player> Igraci = new List<Player>();
                while (!citanje.EndOfStream)
                {
                    Igraci.Add(Player.GetPlayerFromString(citanje.ReadLine()));
                }
                return Igraci;
            }
        }
        public static string DovacanjeTipaTima(TipTima tipTima, string FifaCode)
        {
            TipTima Tip = tipTima == TipTima.Muski ? TipTima.Muski : TipTima.Zenski;

            return "../../../WindowsFormsApp/bin/debug/" + Tip + "_" + FifaCode + ".txt";
        }
        public static Task<List<Match>> PodaciZaTim(string FifaCode, TipTima tipTima)
        {
            return Task.Run(() => {
                String url = "";
                if (tipTima == TipTima.Muski)
                {
                    //info za muške
                    url = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
                    
                }
                else
                {
                    //info za ženske
                    url = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
 
                }
                var restKlijent = new RestClient(url + FifaCode);

                var rezultat = restKlijent.Execute<List<Match>>(new RestRequest());

                return JsonConvert.DeserializeObject<List<Match>>(rezultat.Content);
            });
        }
        
        public static List<String> DohvacanjePostavki()
        {
            if (!PostojecePostavke())
                return null;


            using (StreamReader Citanje = new StreamReader(PostavkeFile))
            {
                List<String> Postavke = new List<String>();
                while (!Citanje.EndOfStream)
                {
                    Postavke.Add(Citanje.ReadLine());

                }
                return Postavke;
            }
        }

        public static bool PostojecePostavke()
        {
            return File.Exists(PostavkeFile);

        }

        public static void SpremanjePostavki(Jezici jezici, TipTima tipTima, string OmiljenaDrzava, Rezolucija rezolucija)
        {
            using (StreamWriter writer = new StreamWriter(PostavkeFile))
            {
                writer.Write(jezici == Jezici.Hrvatski ? "hr" : "en");
                writer.Write(Environment.NewLine);
                writer.Write(tipTima == TipTima.Muski ? "male" : "female");
                writer.Write(Environment.NewLine);
                if (OmiljenaDrzava != null)
                {
                    writer.Write(OmiljenaDrzava);

                }
                writer.Write(Environment.NewLine);
                if (rezolucija != Rezolucija.NemaRezolucije)
                {


                    if (rezolucija == Rezolucija.Mala)
                    {
                        writer.Write(rezolucija = Rezolucija.Mala);
                    }
                    else if (rezolucija == Rezolucija.Srednja)
                    {
                        writer.Write(rezolucija = Rezolucija.Srednja);
                    }
                    else if (rezolucija == Rezolucija.Velika)
                    {
                        writer.Write(rezolucija = Rezolucija.Velika);
                    }

                }
                else
                {
                    writer.Write(rezolucija = Rezolucija.NemaRezolucije);
                }


            }
        }

    }
}
public enum TipTima
{
    Muski, Zenski
}

