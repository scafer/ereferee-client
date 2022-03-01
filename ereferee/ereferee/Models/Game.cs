using System.Collections.Generic;
using System.Threading.Tasks;
using ereferee.Helpers;
using Newtonsoft.Json;

namespace ereferee.Models
{
    public class Game
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("timeStart")]
        public string TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        public string TimeEnd { get; set; }

        [JsonProperty("homeScore")]
        public int HomeScore { get; set; }

        [JsonProperty("visitorScore")]
        public int VisitorScore { get; set; }

        [JsonProperty("homeColor")]
        public string HomeColor { get; set; }

        [JsonProperty("visitorColor")]
        public string VisitorColor { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("creationDate")]
        public string CreationDate { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("homeTeamId")]
        public int HomeTeamId { get; set; }

        [JsonProperty("visitorTeamId")]
        public int VisitorTeamId { get; set; }

        public static async Task<string> Start(int matchId)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[0], matchId.ToString() }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.StartGame + "?gameId=" + matchId);
            return await response;
        }

        public static async Task<string> Finish(Game game)
        {
            Task<string> response = RestConnector.PostObjectToApi(game, RestConnector.FinishGame);
            return await response;
        }

        public static async Task<string> GetGameDataById(int id)
        {
            Task<string> response = RestConnector.GetDataFromApi(RestConnector.GameDataById + "?gameId=" + id);
            return await response;
        }

        public static async Task<string> Delete(int id)
        {
            var values = new Dictionary<string, string>
            {
                { RestConnector.MatchKeys[0], id.ToString() }
            };

            Task<string> response = RestConnector.PostDataToApi(values, RestConnector.DeleteGame + "?gameId=" + id);
            return await response;
        }
    }
}
