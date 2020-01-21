using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMatchPage : ContentPage
    {
        MatchWithTeamsAndMembers matchWithTeamsAndMembers = new MatchWithTeamsAndMembers();

        public AddMatchPage()
        {
            InitializeComponent();

            matchWithTeamsAndMembers.match = new Match();
            matchWithTeamsAndMembers.homeTeam = new Team();
            matchWithTeamsAndMembers.visitorTeam = new Team();
            matchWithTeamsAndMembers.visitorMembers = new List<TeamMember>();
            matchWithTeamsAndMembers.homeMembers = new List<TeamMember>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            foreach (string colorName in Global.NameToColor.Keys)
            {
                colorPicker_home.Items.Add(colorName);
                colorPicker_visitor.Items.Add(colorName);
            }
        }

        async private void Next_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(entryCell_home.Text)) && !(string.IsNullOrEmpty(entryCell_visitor.Text)) && colorPicker_home.SelectedIndex != -1 && colorPicker_visitor.SelectedIndex != -1)
            {
                matchWithTeamsAndMembers.match.timeStart = GetDate(DateStart.Date.ToString("yyyy-MM-dd"), TimeStart.Time.ToString());
                matchWithTeamsAndMembers.match.home_Color = colorPicker_home.Items[colorPicker_home.SelectedIndex];
                matchWithTeamsAndMembers.match.visitor_Color = colorPicker_visitor.Items[colorPicker_visitor.SelectedIndex];

                matchWithTeamsAndMembers.homeTeam.name = entryCell_home.Text;
                matchWithTeamsAndMembers.homeTeam.color = colorPicker_home.Items[colorPicker_home.SelectedIndex];

                matchWithTeamsAndMembers.visitorTeam.name = entryCell_visitor.Text;
                matchWithTeamsAndMembers.visitorTeam.color = colorPicker_visitor.Items[colorPicker_visitor.SelectedIndex];

                await Navigation.PushAsync(new AddHomeTeamPage(matchWithTeamsAndMembers));
            }
            else
            {
                await DisplayAlert("Warning", "Invalid data.", "Ok");
            }
        }

        private void ColorPicker_Home_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxView_home.Color = Global.GetColor(sender);
        }

        private void ColorPicker_Visitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxView_visitor.Color = Global.GetColor(sender);
        }

        private string GetDate(string dateStart, string timeStart)
        {
            return dateStart + "T" + timeStart + ".204Z";
        }
    }
}