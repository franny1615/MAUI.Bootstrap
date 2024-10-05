using MAUIBootstrap;
using SampleApp.Pages;

namespace SampleApp;

public class App : Application
{
    public App()
    {
        Resources.MergedDictionaries.Add(Bootstrap.Styles());
        MainPage = new NavigationPage(new ControlsPage());
    }
}
