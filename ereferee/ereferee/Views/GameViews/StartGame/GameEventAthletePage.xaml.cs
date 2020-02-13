using ereferee.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventMemberPage : ContentPage
    {
        public MatchEventMemberPage(int id, List<Athlete> members)
        {
            InitializeComponent();

            MembersList.ItemsSource = members;

            App.teamId = id;
        }

        private void MembersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var member = e.SelectedItem as Athlete;

            App.memberId = member.Id;

            Navigation.PushAsync(new MatchEventTypePage());
        }
    }
}