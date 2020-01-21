using Newtonsoft.Json;

namespace ereferee.Models
{
    public class Team
    {
        [JsonProperty("teamId")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}