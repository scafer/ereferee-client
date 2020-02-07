using Newtonsoft.Json;
using System.Collections.Generic;

namespace ereferee.Models
{
    public class MatchData
    {
        [JsonProperty("match")]
        public Match Match { get; set; }

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("visitorTeam")]
        public Team VisitorTeam { get; set; }

        [JsonProperty("homeMembers")]
        public List<TeamMember>? HomeMembers { get; set; }

        [JsonProperty("visitorMembers")]
        public List<TeamMember>? VisitorMembers { get; set; }

        [JsonProperty("events")]
        public List<Event>? Events { get; set; }
    }
}