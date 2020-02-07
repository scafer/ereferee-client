using Newtonsoft.Json;

namespace ereferee.Models
{
    public class User
    {
        [JsonProperty("UserID")]
        public string Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}