using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
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

            EcMatchid.Text = App.matchId.ToString();
            EcTeamid.Text = App.teamId.ToString();
            EcMemberid.Text = App.memberId.ToString();
            EcEventtype.Text = App.eventType.ToString();
            EcMatchtime.Text = App.matchTime;
            EcDescription.Text = App.description;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    if (string.IsNullOrEmpty(EnEventNote.Text))
                    {
                        EnEventNote.Text = "event";
                    }

                    Task<string> resultTask = Event.Add(App.eventType, App.Game.Game.Id, App.teamId, App.memberId, EnEventNote.Text.Trim(), StopWatch.ShowTime());
                    string result = await resultTask;

                    await DisplayAlert("Result", result, "OK");

                    if (App.eventType == 5 && App.idScore == 1)
                    {
                        App.homeScore += 1;
                        App.Game.Game.HomeScore = App.homeScore;
                    }
                    else if (App.eventType == 5 && App.idScore != 1)
                    {
                        App.visitorScore += 1;
                        App.Game.Game.VisitorScore = App.visitorScore;
                    }

                    await Navigation.PushAsync(new MatchPage(App.Game));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }
            }
        }
    }
}