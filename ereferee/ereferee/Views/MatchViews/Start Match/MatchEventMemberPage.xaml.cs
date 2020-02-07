using ereferee.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventMemberPage : ContentPage
    {
        public MatchEventMemberPage(int id, List<TeamMember> members)
        {
            InitializeComponent();

            MembersList.ItemsSource = members;

            App.teamId = id;
        }

        private void MembersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var member = e.SelectedItem as TeamMember;

            App.memberId = member.Id;

            Navigation.PushAsync(new MatchEventTypePage());
        }
    }
}