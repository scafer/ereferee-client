﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        public SplashScreenPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LogoImage.ScaleTo(0.9, 1500, Easing.Linear);
            await LogoImage.ScaleTo(1, 1000, Easing.Linear);

            //if (CrossConnectivity.Current.IsConnected)
            //{
            //    // your logic...
            Application.Current.MainPage = new NavigationPage(new MainMenuPage());
            await Navigation.PushAsync(new MainMenuPage());
            //}
            //else
            //{
            //    await DisplayAlert("Error", "No internet access.", "OK");
            //    var closer = DependencyService.Get<ICloseApplication>();
            //    if (closer != null)
            //        closer.closeApplication();
            //}
        }
    }
}