﻿using System;
using System.Threading.Tasks;
using ereferee.Helpers;
using ereferee.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.GameViews.StartGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public MatchPage(GameData game)
        {
            InitializeComponent();
            LbMatchpart.Text = App.matchPart;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = App.Game;

            BtHome.BackgroundColor = App.GetColor(App.Game.Game.HomeColor);
            BtVisitor.BackgroundColor = App.GetColor(App.Game.Game.VisitorColor);

            LbMatchpart.Text = App.matchPart;

            _ = BackgroundAsync();
        }

        private async Task BackgroundAsync()
        {
            while (true)
            {
                LbStopwatch.Text = StopWatch.ShowTime();
                await Task.Delay(1000);
            }
        }

        private void Bt_home_Clicked(object sender, EventArgs e)
        {
            App.idScore = 1;
            Navigation.PushAsync(new MatchEventMemberPage(App.Game.HomeTeam.Id, App.Game.HomeAthletes));
        }

        private void Bt_visitor_Clicked(object sender, EventArgs e)
        {
            App.idScore = 0;
            Navigation.PushAsync(new MatchEventMemberPage(App.Game.VisitorTeam.Id, App.Game.VisitorAthletes));
        }

        private void OtherEvent_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MatchEventsPage());
        }

        private void Pause_Clicked(object sender, EventArgs e)
        {
            StopWatch.Stop();
        }

        private void Resume_Clicked(object sender, EventArgs e)
        {
            StopWatch.Start();
        }
    }
}