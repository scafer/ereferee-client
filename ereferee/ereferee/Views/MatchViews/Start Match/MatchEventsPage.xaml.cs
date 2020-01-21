using ereferee.Helpers;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventsPage : ContentPage
    {
        public MatchEventsPage()
        {
            InitializeComponent();
        }

        private async void Event2Half_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    Task<string> resultTask = Connection.CreateEvent(2, Global.match.match.matchId, StopWatch.ShowTime());
                    string result = await resultTask;

                    Global.matchPart = "2st Half";

                    await Navigation.PushAsync(new MatchPage(Global.match));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }

            }
        }

        private async void EventExtraTime_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    Task<string> resultTask = Connection.CreateEvent(3, Global.match.match.matchId, StopWatch.ShowTime());
                    string result = await resultTask;

                    Global.matchPart = "Extra Time";

                    await Navigation.PushAsync(new MatchPage(Global.match));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }

            }
        }

        private async void EventFinishMatch_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    Task<string> resultTask = Connection.FinishMatch(Global.match.match.matchId, Global.homeScore, Global.visitorScore);
                    string result = await resultTask;

                    await Navigation.PushAsync(new MainMenuPage());
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }

            }
        }
    }
}