using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var app = Application.Current as App;
            en_username.Text = app.Username;
            en_password.Text = app.Password;
            sw_save.IsToggled = bool.Parse(app.BasicAuth);

            Save_Changed();

            base.OnAppearing();
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(en_username.Text)) && !(string.IsNullOrEmpty(en_password.Text)))
            {
                try
                {
                    Task<AuthData> taskResult = Connection.SignIn(en_username.Text, en_password.Text);
                    var result = await taskResult;

                    if (result.token != null)
                    {
                        var app = Application.Current as App;
                        app.Token = result.token;

                        await Navigation.PushAsync(new SplashScreenPage());
                    }
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Authentication error.", "Ok");
                }
            }
            else
                await DisplayAlert("Error", "Invalid username or password.", "Ok");
        }

        private void SignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }

        private void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        private void About_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private void Save_Toggled(object sender, ToggledEventArgs e)
        {
            Save_Changed();
        }

        void Save_Changed()
        {
            var app = Application.Current as App;

            if (sw_save.IsToggled == true)
            {
                app.Username = en_username.Text;
                app.Password = en_password.Text;
                app.BasicAuth = (sw_save.IsToggled).ToString();
            }
            else
            {
                en_username.Text = string.Empty;
                en_password.Text = string.Empty;
                app.Username = string.Empty;
                app.Password = string.Empty;
                app.BasicAuth = (sw_save.IsToggled).ToString();
            }
        }
    }
}