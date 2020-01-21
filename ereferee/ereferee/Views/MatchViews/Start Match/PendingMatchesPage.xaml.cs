using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingMatchesPage : ContentPage
    {
        public PendingMatchesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                GetPendingMatches();
                GetActiveMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
        }

        async void GetPendingMatches()
        {
            Task<string> resultTask = Connection.GetData(Api.Url + Api.GetPendingMatches);
            var result = await resultTask;
            var obj = JsonConvert.DeserializeObject<List<MatchWithTeams>>(result);

            //await DisplayAlert("Message", result, "OK");
            pendingMatchesList.ItemsSource = obj;
        }

        async void GetActiveMatches()
        {
            Task<string> resultTask = Connection.GetData(Api.Url + Api.GetActiveMatches);
            var result = await resultTask;
            var obj = JsonConvert.DeserializeObject<List<MatchWithTeams>>(result);

            //await DisplayAlert("Message", result, "OK");
            activeMatchesList.ItemsSource = obj;
        }

        private void PendingMatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as MatchWithTeams;
            Navigation.PushAsync(new StartMatchPage(match, 0));
        }

        private async void PendingMatchesList_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetPendingMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { pendingMatchesList.IsRefreshing = false; }
        }

        private async void PendingMenuItem_Clicked(object sender, EventArgs e)
        {
            var match = (sender as MenuItem).CommandParameter as MatchWithTeams;
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
                await Connection.DeleteMatch(match.match.matchId);
            GetPendingMatches();
        }

        private void ActiveMenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ActiveMatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as MatchWithTeams;
            Navigation.PushAsync(new StartMatchPage(match, 1));
        }

        private async void ActiveMatchesList_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetActiveMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { activeMatchesList.IsRefreshing = false; }

        }
    }
}