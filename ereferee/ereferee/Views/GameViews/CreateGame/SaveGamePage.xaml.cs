using System;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.CreateGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMatchConfirmationPage : ContentPage
    {
        GameData _gameWithTeamsAndMembers;

        public CreateMatchConfirmationPage(GameData game)
        {
            InitializeComponent();

            _gameWithTeamsAndMembers = game;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = _gameWithTeamsAndMembers;

            HomeTeamMembersList.ItemsSource = _gameWithTeamsAndMembers.HomeAthletes;
            VisitorTeamMembersList.ItemsSource = _gameWithTeamsAndMembers.VisitorAthletes;
        }

        private async void CreateMatch_Clicked(object sender, EventArgs e)
        {
            try
            {
                _gameWithTeamsAndMembers.Game.HomeColor = App.homeColor;
                _gameWithTeamsAndMembers.Game.VisitorColor = App.visitorColor;

                Task<string> resultTask = RestConnector.PostObjectToApi(_gameWithTeamsAndMembers, RestConnector.CreateGame);
                string result = await resultTask;

                if (result != string.Empty)
                {
                    await DisplayAlert("Message", "Game created successfully.", "OK");
                    await Navigation.PushAsync(new MainMenuPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}