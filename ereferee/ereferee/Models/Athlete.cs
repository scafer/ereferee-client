using Newtonsoft.Json;

namespace ereferee.Models
{
    public class Athlete
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("athleteId")]
        public int AthleteId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("dayStart")]
        public string DayStart { get; set; }

        [JsonProperty("dayEnd")]
        public string DayEnd { get; set; }
    }
}