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
        MatchData match;
        int matchType;

        public StartMatchPage(MatchData match, int type)
        {
            InitializeComponent();
            this.match = match;
            BindingContext = match;

            matchType = type;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (matchType == 0)
            {
                Task<string> resultTask = Match.GetPendingById(match.Match.Id);
                string result = await resultTask;

                match = JsonConvert.DeserializeObject<MatchData>(result);
                BindingContext = match;
            }
            else
            {
                Task<string> resultTask = Match.GetActiveById(match.Match.Id);
                string result = await resultTask;

                match = JsonConvert.DeserializeObject<MatchData>(result);
                BindingContext = match;
            }

            homeTeamMembersList.ItemsSource = match.HomeMembers;
            visitorTeamMembersList.ItemsSource = match.VisitorMembers;
        }

        private async void StartMatch_Clicked(object sender, EventArgs e)
        {
            StopWatch.Restart();
            App.matchId = match.Match.Id;
            App.matchPart = "1st Half";

            if (matchType == 0)
            {
                Task<string> taskResult = Match.Start(match.Match.Id);
                string result = await taskResult;


                await DisplayAlert("Message", result, "OK");

                App.match = match;
                App.homeScore = 0;
                App.visitorScore = 0;
                await Navigation.PushAsync(new MatchPage(match));
            }
            else
            {
                App.match = match;
                App.homeScore = App.match.Match.HomeScore; //not working
                App.visitorScore = App.match.Match.VisitorScore; //not working
                await Navigation.PushAsync(new MatchPage(match));
            }
        }
    }
}