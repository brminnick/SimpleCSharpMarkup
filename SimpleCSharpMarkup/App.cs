using Xamarin.Forms;

namespace SimpleCSharpMarkup
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Markup_Experimental" });
            MainPage = new MainPage();
        }
    }
}
