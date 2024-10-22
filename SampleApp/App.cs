using MAUIBootstrap.Resources.Styles;
using SampleApp.Pages;

namespace SampleApp;

public class App : Application
{
    public App()
    {
        Resources.Add(new BootstrapColors());
        Resources.Add(new BootstrapStyles());
        // re-apply saved theme
        MAUIBootstrap.BootstrapColors.CurrentTheme = MAUIBootstrap.BootstrapColors.CurrentTheme;
        MainPage = new NavigationPage(new ControlsPage());
    }
}
