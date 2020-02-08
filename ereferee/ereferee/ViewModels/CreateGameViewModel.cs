using ereferee.Models;
using ereferee.Views.GameViews.CreateGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ereferee.ViewModels
{
    class CreateGameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation;
        public ICommand SetMatchCommand { get; set; }
        public ICommand SetHomeMembersCommand { get; set; }
        public ICommand SetVisitorMembersCommand { get; set; }
        public ICommand CreateMatchCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private GameData gameData;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateGameViewModel(INavigation navigation, GameData gameData)
        {
            SetMatchCommand = new Command(SetMatchExecuted);
            SetHomeMembersCommand = new Command(SetHomeMembersExecuted);
            SetVisitorMembersCommand = new Command(SetVisitorMembersExecuted);
            CreateMatchCommand = new Command(CreateMatchExecuted);
            CancelCommand = new Command(CancelExecuted);

            this.Navigation = navigation;
            this.gameData = gameData;
        }

        public Game Game
        {
            get => gameData.Match;
            set => gameData.Match = value;
        }

        public Team HomeTeam
        {
            get => gameData.HomeTeam;
            set => gameData.HomeTeam = value;
        }

        public Team VisitorTeam
        {
            get => gameData.VisitorTeam;
            set => gameData.VisitorTeam = value;
        }

        public List<Athlete> HomeAthletes
        {
            get => gameData.HomeMembers;
            set => gameData.HomeMembers = value;
        }

        public List<Athlete> VisitorAthletes
        {
            get => gameData.VisitorMembers;
            set => gameData.VisitorMembers = value;
        }

        private async void SetMatchExecuted()
        {
            if (!(string.IsNullOrEmpty(HomeTeam.Name)) && !(string.IsNullOrEmpty(VisitorTeam.Name)))
            {

                await Navigation.PushAsync(new AddHomeTeamPage(gameData));
            }
            else
            {
                App.DisplayMessage("Warning", "Invalid data.", "Ok");
            }
        }

        private void SetHomeMembersExecuted()
        {
            throw new NotImplementedException();
        }

        private void SetVisitorMembersExecuted()
        {
            throw new NotImplementedException();
        }

        private void CreateMatchExecuted()
        {
            throw new NotImplementedException();
        }

        private async void CancelExecuted()
        {
            await Navigation.PopModalAsync();
        }
    }
}
