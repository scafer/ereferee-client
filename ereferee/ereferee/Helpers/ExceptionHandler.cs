using System.Net.Http;
using Xamarin.Forms;

namespace ereferee.Helpers
{
    public static class ExceptionHandler
    {
        public static void HttpRequestException(HttpRequestException exception)
        {
            Application.Current.MainPage.DisplayAlert("Alert", exception.Message, "OK");
        }
    }
}