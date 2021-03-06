﻿using ereferee.Models;
using ereferee.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.AuthenticationViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private User user = new User();

        public SignInPage()
        {
            InitializeComponent();
            BindingContext = new AuthenticationViewModel(Navigation, user);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var app = Application.Current as App;
            Username.Text = app.Username;
            Password.Text = app.Password;
            SwSave.IsToggled = bool.Parse(app.BasicAuth);

            Save_Changed();
        }

        private void Save_Toggled(object sender, ToggledEventArgs e)
        {
            Save_Changed();
        }

        private void Save_Changed()
        {
            var app = Application.Current as App;

            if (SwSave.IsToggled)
            {
                app.Username = Username.Text;
                app.Password = Password.Text;
                app.BasicAuth = (SwSave.IsToggled).ToString();
            }
            else
            {
                Username.Text = string.Empty;
                Password.Text = string.Empty;
                app.Username = string.Empty;
                app.Password = string.Empty;
                app.BasicAuth = (SwSave.IsToggled).ToString();
            }
        }
    }
}