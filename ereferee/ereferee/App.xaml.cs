using ereferee.Views;
using Xamarin.Forms;

namespace ereferee
{
    public partial class App : Application
    {
        private const string UsernameKey = "Username";
        private const string PasswordKey = "Password";
        private const string AuthKey = "false";
        private const string TokenKey = "";

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

        public string Username
        {
            get
            {
                if (Properties.ContainsKey(UsernameKey))
                    return Properties[UsernameKey].ToString();
                return "";
            }
            set { Properties[UsernameKey] = value; }
        }

        public string Password
        {
            get
            {
                if (Properties.ContainsKey(PasswordKey))
                    return Properties[PasswordKey].ToString();
                return "";
            }
            set { Properties[PasswordKey] = value; }
        }

        public string BasicAuth
        {
            get
            {
                if (Properties.ContainsKey(AuthKey))
                    return Properties[AuthKey].ToString();
                return "false";
            }
            set { Properties[AuthKey] = value; }
        }

        public string Token
        {
            get
            {
                if (Properties.ContainsKey(TokenKey))
                    return Properties[TokenKey].ToString();
                return "";
            }
            set { Properties[TokenKey] = value; }
        }
    }
}