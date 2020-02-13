using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventTypePage : ContentPage
    {
        public MatchEventTypePage()
        {
            InitializeComponent();
        }

        private void Bt_event5_Clicked(object sender, EventArgs e)
        {
            App.eventType = 5;
            Navigation.PushAsync(new MatchEventConfirmationPage());
        }

        private void Bt_event7_Clicked(object sender, EventArgs e)
        {
            App.eventType = 7;
            Navigation.PushAsync(new MatchEventConfirmationPage());
        }

        private void Bt_event8_Clicked(object sender, EventArgs e)
        {
            App.eventType = 8;
            Navigation.PushAsync(new MatchEventConfirmationPage());
        }

        private void Bt_event9_Clicked(object sender, EventArgs e)
        {
            App.eventType = 9;
            Navigation.PushAsync(new MatchEventConfirmationPage());
        }

        private void Bt_event10_Clicked(object sender, EventArgs e)
        {
            App.eventType = 10;
            Navigation.PushAsync(new MatchEventConfirmationPage());
        }
    }
}