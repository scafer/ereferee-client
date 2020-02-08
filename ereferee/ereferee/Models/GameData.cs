using Newtonsoft.Json;
using System.Collections.Generic;

#nullable enable
namespace ereferee.Models
{
    public class GameData
    {
        [JsonProperty("Game")]
        public Game? Match { get; set; }

        [JsonProperty("homeTeam")]
        public Team? HomeTeam { get; set; }

        [JsonProperty("visitorTeam")]
        public Team? VisitorTeam { get; set; }

        [JsonProperty("homeMembers")]
        public List<Athlete>? HomeMembers { get; set; }

        [JsonProperty("visitorMembers")]
        public List<Athlete>? VisitorMembers { get; set; }

        [JsonProperty("events")]
        public List<Event>? Events { get; set; }
    }
}