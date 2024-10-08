using MAUIBootstrap.Resources.Styles;
using SampleApp.Pages;

namespace SampleApp;

public class App : Application
{
    public App()
    {
        Resources.Add(new BootstrapColors());
        Resources.Add(new BootstrapStyles());
        MainPage = new NavigationPage(new ControlsPage());
    }
}
