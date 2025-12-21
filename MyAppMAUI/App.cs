using MyAppMAUI.Pages;

namespace MyAppMAUI
{
    public partial class App : Application
    {
        public App()
        {
            this
            .Resources(AppStyles.Default)
            // Sayfayı NavigationPage içine alıyoruz ki sayfalar arası geçiş yapabilsin
            .MainPage(new NavigationPage(new LoginPage()));
        }
    }
}