using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCLibrary.Modeli
{
    public class Match
    {
        [JsonProperty("venue")]
        public String Venue { get; set; }

        [JsonProperty("location")]
        public String Location { get; set; }

        [JsonProperty("attendance")]
        public String Attendance { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("officials")]
        public List<String> Officials { get; set; }

        [JsonProperty("stage_name")]
        public String StageName { get; set; }

        [JsonProperty("home_team_country")]
        public String HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public String AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("winner")]
        public String Winner { get; set; }

        [JsonProperty("winner_code")]
        public String WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public TeamMatchStats HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public TeamMatchStats AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTimeOffset? LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTimeOffset? LastScoreUpdateAt { get; set; }
    }
}
