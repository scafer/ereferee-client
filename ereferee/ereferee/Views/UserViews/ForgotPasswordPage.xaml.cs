using ereferee.Helpers;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        async private void EmailMe_Clicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(en_username.Text)) || !(string.IsNullOrEmpty(en_email.Text)))
            {
                try
                {
                    Task<string> taskResult = Connection.ResetPassword(en_username.Text, en_email.Text);
                    string result = await taskResult;

                    await DisplayAlert("Message", "Check your inbox.", "Ok");
                    await Navigation.PopModalAsync();
                }
                catch (Exception)
                {
                    await DisplayAlert("Warning", "Communication error.", "OK");
                }
            }
            else
                await DisplayAlert("Warning", "Invalid username or email.", "Ok");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}