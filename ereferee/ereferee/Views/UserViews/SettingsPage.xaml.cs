using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var app = Application.Current as App;
            En_Url.Text = app.ApiUrl;

            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;

            var response = await DisplayAlert("Alert", "Do you want to save?", "Yes", "Cancel");
            if (response)
            {
                app.ApiUrl = En_Url.Text;
                await Navigation.PopModalAsync();
            }
        }
    }
}