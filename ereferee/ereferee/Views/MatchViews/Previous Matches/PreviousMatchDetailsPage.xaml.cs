using ereferee.Helpers;
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
        MatchWithTeamsAndMembersAndEvents match;
        MatchWithTeams matchWithTeams;

        public PreviousMatchDetailsPage(MatchWithTeams match)
        {
            InitializeComponent();

            matchWithTeams = match;
            BindingContext = match;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetMatchDetails();
        }

        async void GetMatchDetails()
        {
            Task<string> resultTask = Connection.GetPreviousMatchById(matchWithTeams.match.matchId);
            string result = await resultTask;

            match = JsonConvert.DeserializeObject<MatchWithTeamsAndMembersAndEvents>(result);
            BindingContext = match;

            homeTeamMembersList.ItemsSource = match.homeMembers;
            visitorTeamMembersList.ItemsSource = match.visitorMembers;
            matchEventsList.ItemsSource = match.events;

            DrawChart();
        }


        void DrawChart()
        {
            int hyellowcard = 0;
            int hredcard = 0;
            int vyellowcard = 0;
            int vredcard = 0;

            foreach (Event events in match.events)
            {
                foreach (TeamMember member in match.homeMembers)
                {
                    if (events.memberID == member.memberID && events.eventType == 7)
                    {
                        hyellowcard++;
                    }
                    else if (events.memberID == member.memberID && events.eventType == 8)
                    {
                        hredcard++;
                    }
                }
                foreach (TeamMember member in match.visitorMembers)
                {
                    if (events.memberID == member.memberID && events.eventType == 7)
                    {
                        vyellowcard++;
                    }
                    else if (events.memberID == member.memberID && events.eventType == 8)
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
            Chart_Cards.Chart = new BarChart { Entries = entries };

        }
    }
}