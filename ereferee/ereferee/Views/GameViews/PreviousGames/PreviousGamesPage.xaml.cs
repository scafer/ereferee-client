using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.PreviousGames
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviousMatchesPage : ContentPage
    {
        public PreviousMatchesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                GetPreviousMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
        }

        private async void GetPreviousMatches()
        {
            Task<string> resultTask = RestConnector.GetDataFromApi(RestConnector.PreviousGames);
            var result = await resultTask;
            var matches = JsonConvert.DeserializeObject<List<Game>>(result);
            MatchesList.ItemsSource = matches;
        }

        private void MatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as Game;
            Navigation.PushAsync(new PreviousMatchDetailsPage(match));
        }

        private void MatchesList_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetPreviousMatches();
            }
            catch (Exception ex) { DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { MatchesList.IsRefreshing = false; }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                MatchesList.IsRefreshing = true;

                var match = (sender as MenuItem).CommandParameter as GameData;
                var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
                if (response)
                    await Game.Delete(match.Game.Id);

                GetPreviousMatches();
            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
            finally { MatchesList.IsRefreshing = false; }
        }
    }
}