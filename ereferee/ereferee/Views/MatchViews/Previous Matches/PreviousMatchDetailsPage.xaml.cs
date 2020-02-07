using ereferee.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviousMatchDetailsPage : ContentPage
    {
        MatchData match;

        public PreviousMatchDetailsPage(MatchData match)
        {
            InitializeComponent();

            this.match = match;
            BindingContext = match;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetMatchDetails();
        }

        private async void GetMatchDetails()
        {
            Task<string> resultTask = Match.GetPreviousById(match.Match.Id);
            string result = await resultTask;

            match = JsonConvert.DeserializeObject<MatchData>(result);
            BindingContext = match;

            HomeTeamMembersList.ItemsSource = match.HomeMembers;
            VisitorTeamMembersList.ItemsSource = match.VisitorMembers;
            MatchEventsList.ItemsSource = match.Events;

            DrawChart();
        }

        private void DrawChart()
        {
            int hyellowcard = 0;
            int hredcard = 0;
            int vyellowcard = 0;
            int vredcard = 0;

            foreach (Event events in match.Events)
            {
                foreach (TeamMember member in match.HomeMembers)
                {
                    if (events.MemberId == member.Id && events.EventType == 7)
                    {
                        hyellowcard++;
                    }
                    else if (events.MemberId == member.Id && events.EventType == 8)
                    {
                        hredcard++;
                    }
                }
                foreach (TeamMember member in match.VisitorMembers)
                {
                    if (events.MemberId == member.Id && events.EventType == 7)
                    {
                        vyellowcard++;
                    }
                    else if (events.MemberId == member.Id && events.EventType == 8)
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