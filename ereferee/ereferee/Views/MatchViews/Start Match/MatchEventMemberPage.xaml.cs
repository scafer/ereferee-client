using ereferee.Helpers;
using ereferee.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventMemberPage : ContentPage
    {
        public MatchEventMemberPage(int Id, List<TeamMember> members)
        {
            InitializeComponent();

            membersList.ItemsSource = members;

            Global.teamId = Id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void MembersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var member = e.SelectedItem as TeamMember;

            Global.memberId = member.memberID;

            Navigation.PushAsync(new MatchEventTypePage());
        }
    }
}