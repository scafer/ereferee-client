using ereferee.Models;
using ereferee.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.AuthenticationViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        User user = new User();

        public ForgotPasswordPage()
        {
            InitializeComponent();
            BindingContext = new AuthenticationViewModel(Navigation, user);
        }
    }
}