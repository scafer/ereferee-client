using ereferee.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ereferee.Models
{
    public class Match
    {
        [JsonProperty("matchId")]
        public int Id { get; set; }

        [JsonProperty("timeStart")]
        public string TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        public string TimeEnd { get; set; }

        [JsonProperty("home_Score")]
        public int HomeScore { get; set; }

        [JsonProperty("home_Color")]
        public string HomeColor { get; set; }

        [JsonProperty("visitor_Score")]
        public int VisitorScore { get; set; }

        [JsonProperty("visitor_Color")]
        public string VisitorColor { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("dt_Creation")]
        public string CreationDate { get; set; }

        [JsonProperty("matchOwnerId")]
        public int MatchOwnerId { get; set; }

        [JsonProperty("homeTeamId")]
        public int HomeTeamId { get; set; }

        [JsonProperty("visitorId")]
        public int VisitorId { get; set; }

        public static async Task<string> Start(int matchId)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[0], matchId.ToString() }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.BeginMatch);
            return await response;
        }

        public static async Task<string> Finish(int matchId, int homeScore, int visitorScore)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[0], matchId.ToString() },
                { RestConnector.MatchKeys[6], homeScore.ToString() },
                { RestConnector.MatchKeys[7], visitorScore.ToString() }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.FinishMatch);
            return await response;
        }

        public static async Task<string> GetPendingById(int id)
        {
            Task<string> response = RestConnector.GetDataFromApi(RestConnector.PendingMatchById + "?matchID=" + id);
            return await response;
        }

        public static async Task<string> GetPreviousById(int id)
        {
            Task<string> response = RestConnector.GetDataFromApi(RestConnector.PreviousMatchById + "?matchID=" + id);
            return await response;
        }

        public static async Task<string> GetActiveById(int id)
        {
            Task<string> response = RestConnector.GetDataFromApi(RestConnector.ActiveMatchById + "?matchID=" + id);
            return await response;
        }

        public static async Task<string> Delete(int id)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[0], id.ToString() }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.DeleteMatch);
            return await response;
        }
    }
}
