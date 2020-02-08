using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartMatchPage : ContentPage
    {
        GameData _game;
        int matchType;

        public StartMatchPage(GameData game, int type)
        {
            InitializeComponent();
            this._game = game;
            BindingContext = game;

            matchType = type;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (matchType == 0)
            {
                Task<string> resultTask = Game.GetGameDataById(_game.Match.Id);
                string result = await resultTask;

                _game = JsonConvert.DeserializeObject<GameData>(result);
                BindingContext = _game;
            }
            else
            {
                Task<string> resultTask = Game.GetGameDataById(_game.Match.Id);
                string result = await resultTask;

                _game = JsonConvert.DeserializeObject<GameData>(result);
                BindingContext = _game;
            }

            homeTeamMembersList.ItemsSource = _game.HomeMembers;
            visitorTeamMembersList.ItemsSource = _game.VisitorMembers;
        }

        private async void StartMatch_Clicked(object sender, EventArgs e)
        {
            StopWatch.Restart();
            App.matchId = _game.Match.Id;
            App.matchPart = "1st Half";

            if (matchType == 0)
            {
                Task<string> taskResult = Game.Start(_game.Match.Id);
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
                App.homeScore = App.Game.Match.HomeScore; //not working
                App.visitorScore = App.Game.Match.VisitorScore; //not working
                await Navigation.PushAsync(new MatchPage(_game));
            }
        }
    }
}