using Newtonsoft.Json;

namespace ereferee.Models
{
    public class AuthData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("tokenExpirationTime")]
        public string TokenExpirationTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}