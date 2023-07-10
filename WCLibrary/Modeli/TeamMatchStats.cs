using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCLibrary.Modeli
{
    public class TeamMatchStats
    {
        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("goals")]
        public long? Goals { get; set; }

        [JsonProperty("penalties")]
        public long? Penalties { get; set; }
    }
}
