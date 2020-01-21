using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHomeTeamPage : ContentPage
    {
        ObservableCollection<TeamMember> _members = new ObservableCollection<TeamMember>();
        MatchWithTeamsAndMembers matchWithTeamsAndMembers;

        public AddHomeTeamPage(MatchWithTeamsAndMembers match)
        {
            InitializeComponent();

            matchWithTeamsAndMembers = match;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            membersList.ItemsSource = _members;

            foreach (string roleName in Global.RoleToName.Keys)
            {
                memberRolePicker.Items.Add(roleName);
            }
        }

        private async void MenuItem_Delete_Clicked(object sender, EventArgs e)
        {
            var member = (sender as MenuItem).CommandParameter as TeamMember;
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
                _members.Remove(member);
        }

        private void MenuItem_Edit_Clicked(object sender, EventArgs e)
        {

        }

        private void AddMember_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(memberName.Text)) && !(string.IsNullOrEmpty(memberNumber.Text)) && memberRolePicker.SelectedIndex != -1)
            {
                TeamMember teamMember = new TeamMember();
                teamMember.name = memberName.Text;
                teamMember.number = int.Parse(memberNumber.Text);

                string roleName = memberRolePicker.Items[memberRolePicker.SelectedIndex];
                teamMember.role = Global.GetMemberRole(roleName);

                _members.Add(teamMember);
                membersList.ItemsSource = _members;
            }
            else
            {
                DisplayAlert("Warning", "Invalid data.", "OK");
            }
        }

        async private void Next_Clicked(object sender, EventArgs e)
        {
            if (_members.Count > 0)
            {
                matchWithTeamsAndMembers.homeMembers = _members.ToList();
                await Navigation.PushAsync(new AddVisitorTeamPage(matchWithTeamsAndMembers));
            }
            else
            {
                await DisplayAlert("Warning", "Invalid data.", "OK");
            }
        }
    }
}