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
        MatchData matchWithTeamsAndMembers = new MatchData();

        public AddMatchPage()
        {
            InitializeComponent();

            matchWithTeamsAndMembers.Match = new Match();
            matchWithTeamsAndMembers.HomeTeam = new Team();
            matchWithTeamsAndMembers.VisitorTeam = new Team();
            matchWithTeamsAndMembers.VisitorMembers = new List<TeamMember>();
            matchWithTeamsAndMembers.HomeMembers = new List<TeamMember>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            foreach (string colorName in App.NameToColor.Keys)
            {
                ColorPickerHome.Items.Add(colorName);
                ColorPickerVisitor.Items.Add(colorName);
            }
        }

        async private void Next_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(EntryCellHome.Text)) && !(string.IsNullOrEmpty(EntryCellVisitor.Text)) && ColorPickerHome.SelectedIndex != -1 && ColorPickerVisitor.SelectedIndex != -1)
            {
                matchWithTeamsAndMembers.Match.TimeStart = GetDate(DateStart.Date.ToString("yyyy-MM-dd"), TimeStart.Time.ToString());
                matchWithTeamsAndMembers.Match.HomeColor = ColorPickerHome.Items[ColorPickerHome.SelectedIndex];
                matchWithTeamsAndMembers.Match.VisitorColor = ColorPickerVisitor.Items[ColorPickerVisitor.SelectedIndex];

                matchWithTeamsAndMembers.HomeTeam.Name = EntryCellHome.Text;
                matchWithTeamsAndMembers.HomeTeam.Color = ColorPickerHome.Items[ColorPickerHome.SelectedIndex];

                matchWithTeamsAndMembers.VisitorTeam.Name = EntryCellVisitor.Text;
                matchWithTeamsAndMembers.VisitorTeam.Color = ColorPickerVisitor.Items[ColorPickerVisitor.SelectedIndex];

                await Navigation.PushAsync(new AddHomeTeamPage(matchWithTeamsAndMembers));
            }
            else
            {
                await DisplayAlert("Warning", "Invalid data.", "Ok");
            }
        }

        private void ColorPicker_Home_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoxViewHome.Color = App.GetColor(sender);
        }

        private void ColorPicker_Visitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoxViewVisitor.Color = App.GetColor(sender);
        }

        private string GetDate(string dateStart, string timeStart)
        {
            return dateStart + "T" + timeStart + ".204Z";
        }
    }
}