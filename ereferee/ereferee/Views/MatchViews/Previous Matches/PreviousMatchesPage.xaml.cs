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
    public partial class PreviousMatchesPage : ContentPage
    {
        public PreviousMatchesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                GetPreviousMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
        }

        async void GetPreviousMatches()
        {
            Task<string> resultTask = Connection.GetData(Api.Url + Api.GetPreviousMatches);
            var result = await resultTask;
            var obj = JsonConvert.DeserializeObject<List<MatchWithTeams>>(result);

            //await DisplayAlert("Message", result, "OK");
            matchesList.ItemsSource = obj;
        }

        private void MatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as MatchWithTeams;
            Navigation.PushAsync(new PreviousMatchDetailsPage(match));
        }

        private void MatchesList_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetPreviousMatches();
            }
            catch (Exception ex) { DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { matchesList.IsRefreshing = false; }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                matchesList.IsRefreshing = true;

                var match = (sender as MenuItem).CommandParameter as MatchWithTeams;
                var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
                if (response)
                    await Connection.DeleteMatch(match.match.matchId);
                GetPreviousMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { matchesList.IsRefreshing = false; }
        }
    }
}