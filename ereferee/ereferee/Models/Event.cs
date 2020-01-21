using ereferee.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ereferee.Models
{
    public class Event
    {
        [JsonProperty("matchID")]
        public int MatchId { get; set; }

        [JsonProperty("userID")]
        public int UserId { get; set; }

        [JsonProperty("memberID")]
        public int MemberId { get; set; }

        [JsonProperty("eventType")]
        public int EventType { get; set; }

        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        [JsonProperty("event_Description")]
        public string EventDescription { get; set; }

        [JsonProperty("reg")]
        public string Reg { get; set; }

        public static async Task<string> Add(int eventType, int matchId, int teamId, int memberId, string description, string matchTime)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[1], eventType.ToString() },
                { RestConnector.MatchKeys[0], matchId.ToString() },
                { RestConnector.MatchKeys[2], teamId.ToString() },
                { RestConnector.MatchKeys[3], memberId.ToString() },
                { RestConnector.MatchKeys[4], description },
                { RestConnector.MatchKeys[5], matchTime }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.CreateMatchEvents);
            return await response;
        }

        public static async Task<string> Add(int eventType, int matchId, string matchTime)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[1], eventType.ToString() },
                { RestConnector.MatchKeys[0], matchId.ToString() },
                { RestConnector.MatchKeys[5], matchTime }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.CreateMatchEvents);
            return await response;
        }
    }
}
