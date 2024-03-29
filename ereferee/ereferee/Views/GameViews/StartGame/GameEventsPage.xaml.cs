﻿using System;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchEventsPage : ContentPage
    {
        public MatchEventsPage()
        {
            InitializeComponent();
        }

        private async void Event2Half_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    var resultTask = Event.Add(2, App.Game.Game.Id, StopWatch.ShowTime());
                    await resultTask;

                    App.matchPart = "2st Half";

                    await Navigation.PushAsync(new MatchPage(App.Game));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }

            }
        }

        private async void EventExtraTime_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    Task<string> resultTask = Event.Add(3, App.Game.Game.Id, StopWatch.ShowTime());
                    await resultTask;

                    App.matchPart = "Extra Time";

                    await Navigation.PushAsync(new MatchPage(App.Game));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }

            }
        }

        private async void EventFinishMatch_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "Cancel");
            if (response)
            {
                try
                {
                    App.Game.Game.HomeScore = App.homeScore;
                    App.Game.Game.VisitorScore = App.visitorScore;
                    var resultTask = Game.Finish(App.Game.Game);
                    await resultTask;
                    await Navigation.PushAsync(new MainMenuPage());
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }
            }
        }
    }
}