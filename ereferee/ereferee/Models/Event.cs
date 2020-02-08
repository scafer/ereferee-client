using ereferee.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ereferee.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("gameId")]
        public int GameId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("athleteId")]
        public int AthleteId { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("eventType")]
        public int EventType { get; set; }

        [JsonProperty("eventDescription")]
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

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.RegisterEvent);
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

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.RegisterEvent);
            return await response;
        }
    }
}
