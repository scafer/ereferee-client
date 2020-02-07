using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void CreateMatch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMatchPage());
        }

        private void StartMatch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PendingMatchesPage());
        }

        private void PreviousMatches_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreviousMatchesPage());
        }
    }
}