using Newtonsoft.Json;
using System;

namespace ereferee.Models
{
    public class Athlete
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("role")]
        public int Role { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("dayStart")]
        public DateTime DayStart { get; set; }

        [JsonProperty("dayEnd")]
        public string DayEnd { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}