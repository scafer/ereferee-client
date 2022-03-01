using System;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartMatchPage : ContentPage
    {
        GameData _game;
        Game g;
        int matchType;

        public StartMatchPage(Game g, int type)
        {
            InitializeComponent();
            this.g = g;
            //BindingContext = game;

            matchType = type;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (matchType == 0)
            {
                Task<string> resultTask = Game.GetGameDataById(g.Id);
                string result = await resultTask;

                _game = JsonConvert.DeserializeObject<GameData>(result);
                BindingContext = _game;
            }
            else
            {
                Task<string> resultTask = Game.GetGameDataById(g.Id);
                string result = await resultTask;

                _game = JsonConvert.DeserializeObject<GameData>(result);
                BindingContext = _game;
            }

            homeTeamMembersList.ItemsSource = _game.HomeAthletes;
            visitorTeamMembersList.ItemsSource = _game.VisitorAthletes;
        }

        private async void StartMatch_Clicked(object sender, EventArgs e)
        {
            StopWatch.Restart();
            App.matchId = _game.Game.Id;
            App.matchPart = "1st Half";

            if (matchType == 0)
            {
                Task<string> taskResult = Game.Start(_game.Game.Id);
                string result = await taskResult;


                await DisplayAlert("Message", result, "OK");

                App.Game = _game;
                App.homeScore = 0;
                App.visitorScore = 0;
                await Navigation.PushAsync(new MatchPage(_game));
            }
            else
            {
                App.Game = _game;
                App.homeScore = App.Game.Game.HomeScore; //not working
                App.visitorScore = App.Game.Game.VisitorScore; //not working
                await Navigation.PushAsync(new MatchPage(_game));
            }
        }
    }
}