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
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        MAUIBootstrap.DynamicConstants.Instance.RegularFont = Constants.RegularFont;
        MAUIBootstrap.DynamicConstants.Instance.BoldFont = Constants.MediumFont;
        
        return new Window(new NavigationPage(new ControlsPage()));
    }
}
