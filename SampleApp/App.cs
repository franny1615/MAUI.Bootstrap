using SampleApp.Pages;

namespace SampleApp;

public class App : Application
{
    public App()
    {
        // leaving here for future reference
        // Resources.MergedDictionaries.Add(new Resources.Styles.Colors());
        // Resources.MergedDictionaries.Add(new Resources.Styles.Styles());

        MainPage = new NavigationPage(new ControlsPage());
    }
}
