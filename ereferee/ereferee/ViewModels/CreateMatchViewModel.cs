using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ereferee.Models;
using ereferee.Views;
using Xamarin.Forms;

namespace ereferee.ViewModels
{
    class CreateMatchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation;
        public ICommand SetMatchCommand { get; set; }
        public ICommand SetHomeMembersCommand { get; set; }
        public ICommand SetVisitorMembersCommand { get; set; }
        public ICommand CreateMatchCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private MatchData matchData;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateMatchViewModel(INavigation navigation, MatchData matchData)
        {
            SetMatchCommand = new Command(SetMatchExecuted);
            SetHomeMembersCommand = new Command(SetHomeMembersExecuted);
            SetVisitorMembersCommand = new Command(SetVisitorMembersExecuted);
            CreateMatchCommand = new Command(CreateMatchExecuted);
            CancelCommand = new Command(CancelExecuted);

            this.Navigation = navigation;
            this.matchData = matchData;
        }

        public Match Match
        {
            get => matchData.Match;
            set => matchData.Match = value;
        }

        public Team HomeTeam
        {
            get => matchData.HomeTeam;
            set => matchData.HomeTeam = value;
        }

        public Team VisitorTeam
        {
            get => matchData.VisitorTeam;
            set => matchData.VisitorTeam = value;
        }

        public List<TeamMember> HomeMembers
        {
            get => matchData.HomeMembers;
            set => matchData.HomeMembers = value;
        }

        public List<TeamMember> VisitorMembers
        {
            get => matchData.VisitorMembers;
            set => matchData.VisitorMembers = value;
        }

        private async void SetMatchExecuted()
        {
            if (!(string.IsNullOrEmpty(HomeTeam.Name)) && !(string.IsNullOrEmpty(VisitorTeam.Name)))
            {

                await Navigation.PushAsync(new AddHomeTeamPage(null));
            }
            else
            {
                App.DisplayMessage("Warning", "Invalid data.", "Ok");
            }
        }

        private async void SetHomeMembersExecuted()
        {
            throw new NotImplementedException();
        }

        private async void SetVisitorMembersExecuted()
        {
            throw new NotImplementedException();
        }

        private async void CreateMatchExecuted()
        {
            throw new NotImplementedException();
        }

        private async void CancelExecuted()
        {
            await Navigation.PopModalAsync();
        }
    }
}
