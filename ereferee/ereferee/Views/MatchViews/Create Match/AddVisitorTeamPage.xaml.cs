using ereferee.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVisitorTeamPage : ContentPage
    {
        ObservableCollection<TeamMember> _members = new ObservableCollection<TeamMember>();
        MatchData matchWithTeamsAndMembers;

        public AddVisitorTeamPage(MatchData match)
        {
            InitializeComponent();

            matchWithTeamsAndMembers = match;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MembersList.ItemsSource = _members;

            foreach (string roleName in App.RoleToName.Keys)
            {
                MemberRolePicker.Items.Add(roleName);
            }
        }

        private async void MenuItem_Delete_Clicked(object sender, EventArgs e)
        {
            var member = (sender as MenuItem).CommandParameter as TeamMember;
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
                _members.Remove(member);
        }

        private void AddMember_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(MemberName.Text)) && !(string.IsNullOrEmpty(MemberNumber.Text)) && MemberRolePicker.SelectedIndex != -1)
            {
                TeamMember teamMember = new TeamMember();
                teamMember.Name = MemberName.Text;
                teamMember.Number = int.Parse(MemberNumber.Text);

                string roleName = MemberRolePicker.Items[MemberRolePicker.SelectedIndex];
                teamMember.Role = App.GetMemberRole(roleName);

                _members.Add(teamMember);
                MembersList.ItemsSource = _members;
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
                matchWithTeamsAndMembers.VisitorMembers = _members.ToList();
                await Navigation.PushAsync(new CreateMatchConfirmationPage(matchWithTeamsAndMembers));
            }
            else
            {
                await DisplayAlert("Warning", "Invalid data.", "OK");
            }
        }
    }
}