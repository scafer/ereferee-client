using ereferee.Models;
using ereferee.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMatchPage : ContentPage
    {
        MatchData matchData = new MatchData();

        public AddMatchPage()
        {
            InitializeComponent();
            BindingContext = new CreateMatchViewModel(Navigation, matchData);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillColorPickers();
        }

        private void FillColorPickers()
        {
            foreach (string colorName in App.NameToColor.Keys)
            {
                colorPicker_home.Items.Add(colorName);
                colorPicker_visitor.Items.Add(colorName);
            }
        }

        private void ColorPicker_Home_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxView_home.Color = App.GetColor(sender);
        }

        private void ColorPicker_Visitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxView_visitor.Color = App.GetColor(sender);
        }

        private string GetDate(string dateStart, string timeStart)
        {
            return dateStart + "T" + timeStart + ".204Z";
        }
    }
}