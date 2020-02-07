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
            base.OnAppearing();
            Url.Text = ((App)Application.Current)?.ApiUrl;
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Alert", "Do you want to save?", "Yes", "Cancel");
            if (response)
            {
                ((App)Application.Current).ApiUrl = Url.Text;
                await Navigation.PopModalAsync();
            }
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}