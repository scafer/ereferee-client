using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingMatchesPage : ContentPage
    {
        public PendingMatchesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                GetPendingMatches();
                GetActiveMatches();

            }
            catch (Exception ex) { await DisplayAlert("Error:", ex.ToString(), "OK"); }
        }

        private async void GetPendingMatches()
        {
            Task<string> resultTask = RestConnector.GetDataFromApi(RestConnector.PendingGames);
            var result = await resultTask;
            var matches = JsonConvert.DeserializeObject<List<Game>>(result);

            PendingMatchesList.ItemsSource = matches;
        }

        private async void GetActiveMatches()
        {
            Task<string> resultTask = RestConnector.GetDataFromApi(RestConnector.ActiveGames);
            var result = await resultTask;
            var matches = JsonConvert.DeserializeObject<List<Game>>(result);

            ActiveMatchesList.ItemsSource = matches;
        }

        private void PendingMatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as Game;
            Navigation.PushAsync(new StartMatchPage(match, 0));
        }

        private void PendingMatchesList_Refreshing(object sender, EventArgs e)
        {
            GetPendingMatches();
            PendingMatchesList.IsRefreshing = false;
        }

        private void ActiveMenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ActiveMatchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var match = e.SelectedItem as Game;
            Navigation.PushAsync(new StartMatchPage(match, 1));
        }

        private void ActiveMatchesList_Refreshing(object sender, EventArgs e)
        {
            GetActiveMatches();
            ActiveMatchesList.IsRefreshing = false;
        }
    }
}