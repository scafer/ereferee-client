﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using ereferee.Helpers;
using ereferee.Models;
using ereferee.Views;
using ereferee.Views.AuthenticationViews;
using ereferee.Views.UserViews;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ereferee.ViewModels
{
    class AuthenticationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation;
        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public ICommand SignUpViewCommand { get; set; }
        public ICommand ForgotPasswordViewCommand { get; set; }
        public ICommand SettingsViewCommand { get; set; }
        public ICommand AboutViewCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private User user;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AuthenticationViewModel(INavigation navigation, User user)
        {
            SignInCommand = new Command(SignInExecuted);
            SignUpCommand = new Command(SignUpExecuted);
            ForgotPasswordCommand = new Command(ForgotPasswordExecuted);
            SignUpViewCommand = new Command(SignUpViewExecuted);
            ForgotPasswordViewCommand = new Command(ForgetPasswordViewExecuted);
            SettingsViewCommand = new Command(SettingsViewExecuted);
            AboutViewCommand = new Command(AboutViewExecuted);
            CancelCommand = new Command(CancelExecuted);

            this.user = user;
            this.Navigation = navigation;
        }

        public int UserId
        {
            get => user.Id;
            set => user.Id = value;
        }

        public string Username
        {
            get => user.Username;
            set => user.Username = value;
        }

        public string Password
        {
            get => user.Password;
            set => user.Password = value;
        }

        public string Email
        {
            get => user.Email;
            set => user.Email = value;
        }

        private async void SignInExecuted()
        {
            if (!(string.IsNullOrEmpty(Username)) && !(string.IsNullOrEmpty(Password)))
            {
                var response = RestConnector.PostObjectToApi(new User(Username, GenerateSha256String(Password), Email), RestConnector.SignIn);
                var result = JsonConvert.DeserializeObject<AuthData>(await response);

                if (!string.IsNullOrEmpty(result.Token))
                {
                    RestConnector.token = result.Token;
                    await Navigation.PushAsync(new SplashScreenPage());
                }
                else
                    App.DisplayMessage("Error", "Invalid username or password.", "Ok");
            }
            else
                App.DisplayMessage("Error", "Invalid username or password.", "Ok");
        }

        private async void SignUpExecuted()
        {
            if (!(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password)))
            {
                var response = RestConnector.PostObjectToApi(new User(Username, GenerateSha256String(Password), Email), RestConnector.SignUp);
                var result = JsonConvert.DeserializeObject<SvcResult>(await response);

                App.DisplayMessage("Result", result.ErrorMessage, "OK");
                await Navigation.PopModalAsync();
            }
            else
                App.DisplayMessage("Error:", "Something is wrong.", "OK");
        }

        private async void ForgotPasswordExecuted()
        {
            if (!(string.IsNullOrEmpty(Username)) || !(string.IsNullOrEmpty(Email)))
            {
                var response = RestConnector.PostObjectToApi(new User(Username, null, Email), RestConnector.ResetPassword);
                var result = JsonConvert.DeserializeObject<SvcResult>(await response);

                App.DisplayMessage("Message", result.ErrorMessage, "Ok");
                await Navigation.PopModalAsync();
            }
            else
                App.DisplayMessage("Warning", "Invalid username or email.", "Ok");
        }

        private async void SignUpViewExecuted()
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }

        private async void ForgetPasswordViewExecuted()
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        private async void SettingsViewExecuted()
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }

        private async void AboutViewExecuted()
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void CancelExecuted()
        {
            await Navigation.PopModalAsync();
        }

        private static string GenerateSha256String(string inputString)
        {
            var sb = new StringBuilder();

            using var hash = SHA256.Create();

            var enc = Encoding.UTF8;
            var result = hash.ComputeHash(enc.GetBytes(inputString));

            foreach (var b in result)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}