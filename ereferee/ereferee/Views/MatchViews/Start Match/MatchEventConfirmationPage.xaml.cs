using ereferee.Helpers;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventConfirmationPage : ContentPage
    {
        public MatchEventConfirmationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ec_matchid.Text = Global.matchID.ToString();
            ec_teamid.Text = Global.teamId.ToString();
            ec_memberid.Text = Global.memberId.ToString();
            ec_eventtype.Text = Global.eventType.ToString();
            ec_matchtime.Text = Global.matchTime;
            ec_description.Text = Global.description;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    if (string.IsNullOrEmpty(en_eventNote.Text))
                    {
                        en_eventNote.Text = "event";
                    }

                    Task<string> resultTask = Connection.CreateEvent(Global.eventType, Global.match.match.matchId, Global.teamId, Global.memberId, en_eventNote.Text.Trim(), StopWatch.ShowTime());
                    string result = await resultTask;

                    await DisplayAlert("Result", result, "OK");

                    if (Global.eventType == 5 && Global.idScore == 1)
                    {
                        Global.homeScore += 1;
                        Global.match.match.home_Score = Global.homeScore;
                    }
                    else if (Global.eventType == 5 && !(Global.idScore == 1))
                    {
                        Global.visitorScore += 1;
                        Global.match.match.visitor_Score = Global.visitorScore;
                    }

                    await Navigation.PushAsync(new MatchPage(Global.match));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }
            }
        }
    }
}