using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
namespace SampleApp.Pages;

public class NavigationTabsDemoPage : ContentPage 
{
    private readonly ContentView _CurrentTab = new ContentView();
    private readonly TabControl _TabBar2 = new TabControl();
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
    private TabModel _TabFour = new TabModel()
        .TranslateKey("Tab Four")
        .MaterialIcon(MaterialIcon.Free_breakfast);
    private TabModel _TabFive = new TabModel()
        .TranslateKey("Tab Five")
        .MaterialIcon(MaterialIcon.Free_breakfast);
    private TabModel _TabSix = new TabModel()
        .TranslateKey("Tab Six")
        .MaterialIcon(MaterialIcon.Free_breakfast);
    private TabModel _TabSeven = new TabModel()
        .TranslateKey("Tab Seven")
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
    private readonly Label _TabFourView = new Label()
        .Text("Tab Four")
        .Center();
    private readonly Label _TabFiveView = new Label()
        .Text("Tab Five")
        .Center();
    private readonly Label _TabSixView = new Label()
        .Text("Tab Six")
        .Center();
    private readonly Label _TabSevenView = new Label()
        .Text("Tab Seven")
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
            .OnTabSelected(TabSelected);
        _TabBar2
            .Tabs([
                _TabOne,
                _TabTwo,
                _TabThree,
                _TabFour,
                _TabFive,
                _TabSix,
                _TabSeven
            ])
            .OnTabSelected(TabSelected);

        this
            .Title("Tabs Demo Page")
            .Content(new Grid()
                .RowDefinitions(e => e.Star().Auto().Auto())
                .Children([
                    _CurrentTab.Row(0).FillBothDirections(),
                    _TabBar.Row(1).FillHorizontal(),
                    new ScrollView()
                        .Row(2)
                        .Orientation(ScrollOrientation.Horizontal)
                        .Content(_TabBar2.FillHorizontal())
                ])
            );
    }

    private void TabSelected(object? sender, TabEventArgs e)
    {
        if (e.SelectedTab == null) return;
                
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
        else if (e.SelectedTab.TranslateKey == "Tab Four")
        {
            _CurrentTab.Content(_TabFourView);
        }
        else if (e.SelectedTab.TranslateKey == "Tab Five")
        {
            _CurrentTab.Content(_TabFiveView);
        }
        else if (e.SelectedTab.TranslateKey == "Tab Six")
        {
            _CurrentTab.Content(_TabSixView);
        }
        else if (e.SelectedTab.TranslateKey == "Tab Seven")
        {
            _CurrentTab.Content(_TabSevenView);
        }
    }
}
