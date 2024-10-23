using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
namespace SampleApp.Pages;

public class NavigationTabsDemoPage : ContentPage 
{
    private readonly ContentView _CurrentTab = new ContentView();
    private readonly TabControl _TabBar = new TabControl();
    private TabModel _TabOne = new TabModel()
        .TranslateKey("Tab One")
        .MaterialIcon(MaterialIcon.Live_tv)
        .Active();
    private TabModel _TabTwo = new TabModel()
        .TranslateKey("Tab Two")
        .MaterialIcon(MaterialIcon.Bike_scooter);
    private TabModel _TabThree = new TabModel()
        .TranslateKey("Tab Three")
        .MaterialIcon(MaterialIcon.Free_breakfast);
    private readonly Label _TabOneView = new Label()
        .Text("Tab One")
        .Center();
    private readonly Label _TabTwoView = new Label()
        .Text("Tab Two")
        .Center();
    private readonly Label _TabThreeView = new Label()
        .Text("Tab Three")
        .Center();

    public NavigationTabsDemoPage()
    {
        _CurrentTab.Content(_TabOneView);
        _TabBar
            .Tabs([
                _TabOne,
                _TabTwo,
                _TabThree
            ])
            .OnTabSelected((s,e) =>
            {
                if (e.SelectedTab == null)
                    return;
                
                if (e.SelectedTab.TranslateKey == "Tab One")
                {
                    _CurrentTab.Content(_TabOneView);
                }
                else if (e.SelectedTab.TranslateKey == "Tab Two")
                {
                    _CurrentTab.Content(_TabTwoView);
                }
                else if (e.SelectedTab.TranslateKey == "Tab Three")
                {
                    _CurrentTab.Content(_TabThreeView);
                }
            });

        this
            .Title("Tabs Demo Page")
            .Content(new Grid()
                .RowDefinitions(e => e.Star().Auto())
                .Children([
                    _CurrentTab.Row(0).FillBothDirections(),
                    _TabBar.Row(1).FillHorizontal()
                ])
            );
    }
}
