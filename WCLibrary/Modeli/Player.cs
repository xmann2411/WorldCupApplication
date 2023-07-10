using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCLibrary.Modeli
{
    public class Player
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long? ShirtNumber { get; set; }

        [JsonProperty("position")]
        public String Position { get; set; }
        public int ZabijeniGolovi { get; set; }
        public int ZutiKartoni { get; set; }
        public String Image { get; set; }
        public bool Favorite { get; set; }
        public static Player GetPlayerFromString(string json)
        {
            Player player = new Player();

            try
            {
                var attrs = json.Split(',');
                player.Name = attrs[0];
                player.Captain = bool.Parse(attrs[1]);
                player.ShirtNumber = long.Parse(attrs[2]);
                player.Position = attrs[3];
                player.ZabijeniGolovi = int.Parse(attrs[4]);
                player.ZutiKartoni = int.Parse(attrs[5]);
                player.Image = attrs[6];
                player.Favorite = bool.Parse(attrs[7]);
                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }

}
