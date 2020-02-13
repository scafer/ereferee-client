using ereferee.Models;
using ereferee.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ereferee.Views.AuthenticationViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private User user = new User();

        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new AuthenticationViewModel(Navigation, user);
        }
    }
}