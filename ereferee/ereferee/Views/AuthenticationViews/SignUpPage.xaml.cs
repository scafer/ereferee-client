using ereferee.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(en_username.Text) && string.IsNullOrEmpty(en_email.Text) && string.IsNullOrEmpty(en_password.Text)
                && string.IsNullOrEmpty(en_password2.Text)) && en_password.Text == en_password2.Text.Trim())
            {
                try
                {
                    Task<string> ResultTask = Connection.SignUp(en_username.Text.Trim(), en_password.Text.Trim(), en_email.Text.Trim());
                    string Result = await ResultTask;

                    await DisplayAlert("Result", Result, "OK");
                    await Navigation.PopModalAsync();
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Communication error.", "OK");
                }
            }
            else
                await DisplayAlert("Error:", "Something is wrong.", "OK");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}