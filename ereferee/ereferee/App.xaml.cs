using ereferee.Models;
using ereferee.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ereferee
{
    public partial class App : Application
    {
        private const string UsernameKey = "Username";
        private const string PasswordKey = "Password";
        private const string AuthSaveKey = "false";
        private const string ApiUrlKey = "";

        //TODO: remove this variables
        public static MatchData match;
        public static int eventType;
        public static int matchId;
        public static int teamId;
        public static int memberId;
        public static int homeScore;
        public static int visitorScore;
        public static int idScore;
        public static string matchTime;
        public static string matchPart;
        public static string description;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SignInPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static async void DisplayMessage(string title, string message, string cancel)
        {
            await App.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public static async void DisplayMessage(string title, string message, string cancel, string accept)
        {
            await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public string Username
        {
            get => Properties.ContainsKey(UsernameKey) ? Properties[UsernameKey].ToString() : "";
            set => Properties[UsernameKey] = value;
        }

        public string Password
        {
            get => Properties.ContainsKey(PasswordKey) ? Properties[PasswordKey].ToString() : "";
            set => Properties[PasswordKey] = value;
        }

        public string BasicAuth
        {
            get => Properties.ContainsKey(AuthSaveKey) ? Properties[AuthSaveKey].ToString() : "false";
            set => Properties[AuthSaveKey] = value;
        }

        public string ApiUrl
        {
            get => Properties.ContainsKey(ApiUrlKey) ? Properties[ApiUrlKey].ToString() : "";
            set => Properties[ApiUrlKey] = value;
        }

        public static Color GetColor(string colorName)
        {
            return NameToColor[colorName];
        }

        public static Color GetColor(object sender)
        {
            var picker = (Picker)sender;
            var color = Color.Default;

            if (picker.SelectedIndex != -1)
            {
                var colorName = picker.Items[picker.SelectedIndex];
                color = NameToColor[colorName];
            }
            return color;
        }

        public static int GetMemberRole(string roleName)
        {
            return RoleToName[roleName];
        }

        public static readonly Dictionary<string, int> RoleToName = new Dictionary<string, int>
        {
            {"Player", 1 }, {"Player-Captain", 2}
        };

        public static readonly Dictionary<string, Color> NameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Blue", Color.Blue }, { "Yellow", Color.Yellow },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }
        };
    }
}