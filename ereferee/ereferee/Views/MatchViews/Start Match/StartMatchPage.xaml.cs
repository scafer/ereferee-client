using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartMatchPage : ContentPage
    {
        MatchWithTeamsAndMembersAndEvents match;
        MatchWithTeams matchWithTeams;
        int matchType;

        public StartMatchPage(MatchWithTeams match, int type)
        {
            InitializeComponent();
            matchWithTeams = match;
            BindingContext = match;

            matchType = type;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (matchType == 0)
            {
                Task<string> resultTask = Connection.GetPendingMatchById(matchWithTeams.match.matchId);
                string result = await resultTask;

                match = JsonConvert.DeserializeObject<MatchWithTeamsAndMembersAndEvents>(result);
                BindingContext = match;
            }
            else
            {
                Task<string> resultTask = Connection.GetActiveMatchById(matchWithTeams.match.matchId);
                string result = await resultTask;

                match = JsonConvert.DeserializeObject<MatchWithTeamsAndMembersAndEvents>(result);
                BindingContext = match;
            }

            homeTeamMembersList.ItemsSource = match.homeMembers;
            visitorTeamMembersList.ItemsSource = match.visitorMembers;
        }

        private async void StartMatch_Clicked(object sender, EventArgs e)
        {
            StopWatch.Restart();
            Global.matchID = match.match.matchId;
            Global.matchPart = "1st Half";

            if (matchType == 0)
            {
                Task<string> taskResult = Connection.BeginMatch(matchWithTeams.match.matchId);
                string result = await taskResult;


                await DisplayAlert("Message", result, "OK");

                Global.match = match;
                Global.homeScore = 0;
                Global.visitorScore = 0;
                await Navigation.PushAsync(new MatchPage(match));
            }
            else
            {
                Global.match = match;
                Global.homeScore = Global.match.match.home_Score; //not working
                Global.visitorScore = Global.match.match.visitor_Score; //not working
                await Navigation.PushAsync(new MatchPage(match));
            }
        }
    }
}