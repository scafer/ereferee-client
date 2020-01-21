using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public MatchPage(MatchWithTeamsAndMembersAndEvents match)
        {
            InitializeComponent();
            lb_matchpart.Text = Global.matchPart;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = Global.match;

            bt_home.BackgroundColor = Global.GetColor(Global.match.match.home_Color);
            bt_visitor.BackgroundColor = Global.GetColor(Global.match.match.visitor_Color);

            lb_matchpart.Text = Global.matchPart;

            _ = BackgroundAsync();
        }

        private async Task BackgroundAsync()
        {
            while (true)
            {
                lb_stopwatch.Text = StopWatch.ShowTime();
                await Task.Delay(1000);
            }
        }

        private void Bt_home_Clicked(object sender, EventArgs e)
        {
            Global.idScore = 1;
            Navigation.PushAsync(new MatchEventMemberPage(Global.match.homeTeam.teamId, Global.match.homeMembers));
        }

        private void Bt_visitor_Clicked(object sender, EventArgs e)
        {
            Global.idScore = 0;
            Navigation.PushAsync(new MatchEventMemberPage(Global.match.visitorTeam.teamId, Global.match.visitorMembers));
        }

        private void OtherEvent_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MatchEventsPage());
        }

        private void Pause_Clicked(object sender, EventArgs e)
        {
            StopWatch.Stop();
        }

        private void Resume_Clicked(object sender, EventArgs e)
        {
            StopWatch.Start();
        }
    }
}