using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ereferee.Helpers
{
    public static class RestConnector
    {
        //Authentication
        public static string token;
        public const string SignIn = "/api/Auth/signIn";
        public const string SignUp = "/api/Auth/signUp";

        //Match
        public const string CreateMatch = "/api/match/createMatch";
        public const string BeginMatch = "/api/match/beginMatch";
        public const string FinishMatch = "/api/match/finishMatch";
        public const string PendingMatches = "/api/match/getPendingMatchs";
        public const string PendingMatchById = "/api/match/getPendingMatchByID";
        public const string ActiveMatches = "/api/match/getActiveMatchs";
        public const string ActiveMatchById = "/api/match/getActiveMatchByID";
        public const string PreviousMatches = "/api/match/getPreviousMatchs";
        public const string PreviousMatchById = "/api/match/getPreviousMatchByID";
        public const string CreateMatchEvents = "/api/match/createMatchEvents";
        public const string DeleteMatch = "/api/match/deleteMatch";

        //User
        public const string ResetPassword = "/api/user/resetPassword";
        public const string ChangePassword = "/api/user/changePassword";
        public const string UserInfo = "/api/user/getUserInfo";
        public const string AllUsers = "/api/user/getAllUsers";

        public static readonly string[] UserKeys = new string[] { "Username", "Email", "Password", "oldPassword", "newPassword" };
        public static readonly string[] MatchKeys = new string[] { "matchId", "eventType", "teamId", "memberId", "description", "matchTime", "homeScore", "visitorScore" };

        private const string ApiAuthenticationMode = "Authorization";

        private static string GetApiUrl()
        {
            return (Application.Current as App)?.ApiUrl;
        }

        private static string GetAuthenticationHeader() => "bearer" + " " + token;

        public static async Task<string> GetDataFromApi(string conn)
        {
            var response = string.Empty;
            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Add(ApiAuthenticationMode, GetAuthenticationHeader());
                response = await client.GetStringAsync(GetApiUrl() + conn);
            }
            catch (HttpRequestException ex)
            {
                ExceptionHandler.HttpRequestException(ex);
            }
            return response;
        }

        public static async Task<string> PostObjectToApi(object data, string conn)
        {
            var response = string.Empty;
            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Add(ApiAuthenticationMode, GetAuthenticationHeader());
                var httpResponse = await client.PostAsync(GetApiUrl() + conn,
                    new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                ExceptionHandler.HttpRequestException(ex);
            }
            return response;
        }

        public static async Task<string> PostDataToApi(Dictionary<string, string> values, string conn)
        {
            var response = string.Empty;
            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Add(ApiAuthenticationMode, GetAuthenticationHeader());
                var content = new FormUrlEncodedContent(values);
                var httpResponse = await client.PostAsync(GetApiUrl() + conn, content);
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                ExceptionHandler.HttpRequestException(ex);
            }
            return response;
        }
    }
}