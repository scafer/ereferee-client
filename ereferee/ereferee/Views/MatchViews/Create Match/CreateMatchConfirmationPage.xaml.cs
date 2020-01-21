using ereferee.Helpers;
using ereferee.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMatchConfirmationPage : ContentPage
    {
        MatchData matchWithTeamsAndMembers;

        public CreateMatchConfirmationPage(MatchData match)
        {
            InitializeComponent();

            matchWithTeamsAndMembers = match;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = matchWithTeamsAndMembers;

            HomeTeamMembersList.ItemsSource = matchWithTeamsAndMembers.HomeMembers;
            VisitorTeamMembersList.ItemsSource = matchWithTeamsAndMembers.VisitorMembers;
        }

        async private void CreateMatch_Clicked(object sender, EventArgs e)
        {
            try
            {
                Task<string> resultTask = RestConnector.PostObjectToApi(matchWithTeamsAndMembers, RestConnector.CreateMatch);
                string result = await resultTask;

                //await DisplayAlert("Result", result, "OK");
                if (result != string.Empty)
                {
                    await DisplayAlert("Message", "Match created successfully.", "OK");
                    await Navigation.PushAsync(new MainMenuPage());
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Communication error.", "OK");
            }
        }
    }
}