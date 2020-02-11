using ereferee.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace ereferee.Views.GameViews.PreviousGames
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviousMatchDetailsPage : ContentPage
    {
        GameData _game;

        public PreviousMatchDetailsPage(GameData game)
        {
            InitializeComponent();

            this._game = game;
            BindingContext = game;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetMatchDetails();
        }

        private async void GetMatchDetails()
        {
            Task<string> resultTask = Game.GetGameDataById(_game.Game.Id);
            string result = await resultTask;

            _game = JsonConvert.DeserializeObject<GameData>(result);
            BindingContext = _game;

            HomeTeamMembersList.ItemsSource = _game.HomeAthletes;
            VisitorTeamMembersList.ItemsSource = _game.VisitorAthletes;
            MatchEventsList.ItemsSource = _game.Events;

            DrawChart();
        }

        private void DrawChart()
        {
            int hyellowcard = 0;
            int hredcard = 0;
            int vyellowcard = 0;
            int vredcard = 0;

            foreach (Event events in _game.Events)
            {
                foreach (Athlete member in _game.HomeAthletes)
                {
                    if (events.AthleteId == member.Id && events.EventType == 7)
                    {
                        hyellowcard++;
                    }
                    else if (events.AthleteId == member.Id && events.EventType == 8)
                    {
                        hredcard++;
                    }
                }
                foreach (Athlete member in _game.VisitorAthletes)
                {
                    if (events.AthleteId == member.Id && events.EventType == 7)
                    {
                        vyellowcard++;
                    }
                    else if (events.AthleteId == member.Id && events.EventType == 8)
                    {
                        vredcard++;
                    }
                }
            }

            var entries = new[]
{
    new Entry(hyellowcard)
    {
        Label = "Home",
        ValueLabel = hyellowcard.ToString(),
        Color = SKColor.Parse("#FFFF00"),
        TextColor = SKColor.Parse("000000")
    },
    new Entry(hredcard)
    {
    Label = "Home",
    ValueLabel = hredcard.ToString(),
    Color = SKColor.Parse("#FF0000"),
    TextColor = SKColor.Parse("000000")
    },
    new Entry(vyellowcard)
    {
    Label = "Visitor",
    ValueLabel = vyellowcard.ToString(),
    Color = SKColor.Parse("FFFF00"),
    TextColor = SKColor.Parse("000000")
    },
        new Entry(vredcard)
    {
    Label = "Visitor",
    ValueLabel = vredcard.ToString(),
    Color = SKColor.Parse("#FF0000"),
    TextColor = SKColor.Parse("000000")
    }
};
            ChartCards.Chart = new BarChart { Entries = entries };

        }
    }
}