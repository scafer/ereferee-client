using ereferee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ereferee.Helpers
{
    public static class Connection
    {
        public static async Task<string> GetData(string conn)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + (Application.Current as App)?.Token);
                    return await client.GetStringAsync(conn);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static async Task<string> GetData(string conn, string data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + (Application.Current as App)?.Token);
                return await client.GetStringAsync(conn + data);
            }
        }

        public static async Task<string> PostData(object obj, string conn)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + (Application.Current as App)?.Token);
                    var response = await client.PostAsync(conn, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        private static async Task<string> PostData(Dictionary<string, string> values, string conn, string str)
        {
            str = String.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + (Application.Current as App)?.Token);
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(conn, content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<AuthData> SignIn(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                {"Username", username},
                { "Password", GenerateSha256String(password)}
            };

            var resultTask = PostData(values, Api.Url + Api.SignIn, string.Empty);
            var responseString = await resultTask;
            return JsonConvert.DeserializeObject<AuthData>(responseString);
        }

        public static async Task<string> SignUp(string username, string password, string email)
        {
            var values = new Dictionary<string, string>
                {
                    { "Username", username },
                    { "Email", email },
                    { "Password", GenerateSha256String(password) }
                };

            var resultTask = PostData(values, Api.Url + Api.SignUp, string.Empty);
            return await resultTask;
        }

        public static async Task<string> ResetPassword(string username, string email)
        {
            var values = new Dictionary<string, string>
            {
                { "Username", username },
                { "Email", email }
            };

            var resultTask = PostData(values, Api.Url + Api.ResetPassword, string.Empty);
            return await resultTask;
        }

        public static async Task<string> ChangePassword(string username, string oldPassword, string newPassword)
        {
            var values = new Dictionary<string, string>
            {
                    { "username", username },
                    { "oldPassword", GenerateSha256String(oldPassword)},
                    { "newPassword", GenerateSha256String(newPassword)}
            };

            var resultTask = PostData(values, Api.Url + Api.ChangePassword, string.Empty);
            return await resultTask;
        }

        public static async Task<string> BeginMatch(int id)
        {
            var values = new Dictionary<string, string>
                {
                    { "matchId", id.ToString() }
                };

            var resultTask = PostData(values, Api.Url + Api.BeginMatch, string.Empty);
            return await resultTask;
        }

        public static async Task<string> GetPendingMatchById(int id)
        {
            var resultTask = GetData(Api.Url + Api.GetPendingMatchById, "?matchID=" + id);
            var responseString = await resultTask;
            return responseString;
        }

        public static async Task<string> GetPreviousMatchById(int id)
        {
            var resultTask = GetData(Api.Url + Api.GetPreviousMatchById, "?matchID=" + id);
            return await resultTask;
        }

        public static async Task<string> GetActiveMatchById(int id)
        {
            var resultTask = GetData(Api.Url + Api.GetActiveMatchById, "?matchID=" + id);
            return await resultTask;
        }

        public static async Task<string> DeleteMatch(int id)
        {
            var values = new Dictionary<string, string>
                {
                    { "MatchId", id.ToString() }
                };

            var resultTask = PostData(values, Api.Url + Api.DeleteMatch, string.Empty);
            return await resultTask;
        }

        public static async Task<string> CreateEvent(int eventType, int matchId, int teamId, int memberId, string description, string matchTime)
        {
            var values = new Dictionary<string, string>
                {
                    { "eventType", eventType.ToString() },
                    { "matchID", matchId.ToString() },
                    { "teamId", teamId.ToString() },
                    { "memberId", memberId.ToString()},
                    { "description", description },
                    { "matchTime", matchTime }
                };

            var resultTask = PostData(values, Api.Url + Api.CreateMatchEvents, string.Empty);
            return await resultTask;
        }

        public static async Task<string> CreateEvent(int eventType, int matchId, string matchTime)
        {
            var values = new Dictionary<string, string>
                {
                    { "eventType", eventType.ToString() },
                    { "matchID", matchId.ToString() },
                    { "matchTime", matchTime }
                };

            var resultTask = PostData(values, Api.Url + Api.CreateMatchEvents, string.Empty);
            return await resultTask;
        }

        public static async Task<string> FinishMatch(int matchId, int homeScore, int visitorScore)
        {
            var values = new Dictionary<string, string>
                {
                    { "matchId", matchId.ToString() },
                    { "homeScore", homeScore.ToString() },
                    { "visitorScore", visitorScore.ToString() }
                };

            var resultTask = PostData(values, Api.Url + Api.FinishMatch, string.Empty);
            return await resultTask;
        }

        private static string GenerateSha256String(string inputString)
        {
            var sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(inputString));

                foreach (var b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
