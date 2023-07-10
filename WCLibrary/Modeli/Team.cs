﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCLibrary.Modeli
{
    public class Team
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public char GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long? Wins { get; set; }

        [JsonProperty("draws")]
        public long? Draws { get; set; }

        [JsonProperty("losses")]
        public long? Losses { get; set; }

        [JsonProperty("games_played")]
        public long? GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long? Points { get; set; }

        [JsonProperty("goals_for")]
        public long? GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long? GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long? GoalDifferential { get; set; }

        //public string NazivTima()
        //{
        //    return $"{Country} ({FifaCode})";
        //}

        public string Naziv
        {
            get { return $"{Country} ({FifaCode})"; }
        }
    }
}
