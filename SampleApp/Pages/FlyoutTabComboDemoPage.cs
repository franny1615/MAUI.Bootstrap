using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace SampleApp.Pages;

public class FlyoutTabComboDemoPage : ContentPage
{
	#region UI
	private readonly TabControl _TabBar = new TabControl()
		.Tabs([
			new TabModel()
				.MaterialIcon(MaterialIcon.House)
				.TranslateKey("Dashboard")
				.Active(),
			new TabModel()
				.MaterialIcon(MaterialIcon.Star)
				.TranslateKey("Favorites"),
			new TabModel()
				.MaterialIcon(MaterialIcon.Settings)
				.TranslateKey("Settings")
		]);
	private readonly TabControl _Flyout = new TabControl()
		.Padding(8)
		.Vertical()
		.Tabs([
			new TabModel()
				.MaterialIcon(MaterialIcon.Account_balance)
				.TranslateKey("Banks"),
			new TabModel()
				.MaterialIcon(MaterialIcon.Terminal)
				.TranslateKey("Terminal"),
			new TabModel()
				.MaterialIcon(MaterialIcon.Car_rental)
				.TranslateKey("Car Rental")
		]);
	private readonly Image _HaloImage = new Image()
		.Source("https://picsum.photos/300/120")
		.Aspect(Aspect.AspectFill);
	private readonly Grid _FlyoutLayout = new Grid()
		.RowDefinitions(e => e.Absolute(120).Star())
		.ColumnDefinitions(e => e.Star().Star());
	private readonly Grid _TabBarLayout = new Grid()
		.RowDefinitions(e => e.Auto().Star().Auto());
	private readonly Label _BackButton = new Label()
		.Text(MaterialIcon.Chevron_left)
		.FontFamily(nameof(MaterialIcon))
		.FontSize(32)
		.CenterVertical()
		.Padding(8,0,8,0);
	private readonly Label _Title = new Label()
		.Text(e => e.Translate("Tab w/ Flyout"))
		.FontFamily(DynamicConstants.Instance.BoldFont)
		.FontSize(16)
		.Padding(8);
	private readonly ContentView _PageView = new ContentView()
		.Padding(8);
	private readonly Label _Dashboard = new Label()
		.Text("Dashboard")
		.Center();
	private readonly Label _Favorites = new Label()
		.Text("Favorites")
		.Center();
	private readonly Label _Settings = new Label()
		.Text("Settings")
		.Center();
	private BoxView _HideFlyout = new BoxView()
		.Opacity(0)
		.BackgroundColor(BootstrapColors.Secondary.WithAlpha(0.5f))
		.FillBothDirections()
		.Margin(0,-100,0,-100);
	#endregion

	public FlyoutTabComboDemoPage()
	{
		NavigationPage.SetHasNavigationBar(this, false);

		_FlyoutLayout.Children([
			new Border()
				.Content(_HaloImage)
				.Margin(8)
				.StrokeShape(new RoundRectangle().CornerRadius(12))
				.ZIndex(0)
				.Row(0)
				.Column(0),
			_Flyout
				.ZIndex(0)
				.Column(0)
				.Row(1),
			_TabBarLayout
				.ZIndex(1)
				.Column(0)
				.Row(0)
				.ColumnSpan(2)
				.RowSpan(2)
		]);

		_TabBarLayout.Children([
			_BackButton.Row(0).AlignLeft(),
			_Title.Row(0).CenterHorizontal(),
			_PageView.Row(1).FillBothDirections(),
			_TabBar.Row(2)
		]);

		_TabBarLayout.SetDynamicResource(Grid.BackgroundColorProperty, nameof(BootstrapColors.PageColor));

		this.Content(_FlyoutLayout);

		_BackButton.GestureRecognizers(new TapGestureRecognizer()
			.NumberOfTapsRequired(1)
			.OnTapped((s,e) => {
				Navigation.PopAsync();
			}));
		
		_PageView.Content(_Dashboard);

		_TabBar.OnTabSelected((s,e) => {
			if (e.SelectedTab == null) 
				return;

			if (e.SelectedTab.TranslateKey == "Dashboard")
				_PageView.Content(_Dashboard);
			else if (e.SelectedTab.TranslateKey == "Favorites")
				_PageView.Content(_Favorites);
			else if (e.SelectedTab.TranslateKey == "Settings")
				_PageView.Content(_Settings);
		});
		_Flyout.OnTabSelected((s,e) => {
			if (e.SelectedTab == null) 
				return;

			HideFlyout();

			if (e.SelectedTab.TranslateKey == "Banks")
				_ = Navigation.PushAsync(new NavigationTabsDemoPage());
			else if (e.SelectedTab.TranslateKey == "Terminal")
				_PageView.Content(_Favorites);
			else if (e.SelectedTab.TranslateKey == "Car Rental")
				_PageView.Content(_Settings);
		});

		_HideFlyout.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s,e) => {
					HideFlyout();
				})
		]);

		_FlyoutLayout.GestureRecognizers.Add(new PanGestureRecognizer()
			.OnPanUpdated((s,e) => {
				var display = DeviceDisplay.Current.MainDisplayInfo;
				var halfOfPage = (int)(display.Width / display.Density * 0.55f);

				bool running = e.StatusType == GestureStatus.Running;
				bool complete = e.StatusType == GestureStatus.Completed;

				bool belowMaxThreshold = (int)_TabBarLayout.TranslationX <= halfOfPage;
				bool aboveFlyoutThreshold = (int)_TabBarLayout.TranslationX >= (int)(halfOfPage * 0.5);
				bool belowFlyoutThreshold = (int)_TabBarLayout.TranslationX < (int)(halfOfPage * 0.5);
				bool translationPositive = (int)_TabBarLayout.TranslationX >= 0;

				if (running && belowMaxThreshold) 
				{
					if (aboveFlyoutThreshold)
					{
						ShowFlyout();
					}
					else if (translationPositive)
					{
						_TabBarLayout.TranslationX += e.TotalX;	
					}
				}
				else if (complete && belowFlyoutThreshold)
				{
					HideFlyout();
				}
				else if (complete && aboveFlyoutThreshold)
				{
					ShowFlyout();
				}
			}));
	}

	private void ShowFlyout()
	{
		var display = DeviceDisplay.Current.MainDisplayInfo;
		var halfOfPage = (int)(display.Width / display.Density * 0.55f);
		_TabBarLayout.TranslateTo(halfOfPage, 0, easing: Easing.CubicOut);
		if (!_FlyoutLayout.Contains(_HideFlyout))
		{
			_FlyoutLayout.Add(_HideFlyout.Column(1).Row(0).RowSpan(2).ZIndex(3));
			_HideFlyout.FadeTo(1);
		}
	}

	private async void HideFlyout()
	{
		_ = _HideFlyout.FadeTo(0);
		await _TabBarLayout.TranslateTo(0, 0, easing: Easing.CubicIn);
		_FlyoutLayout.Remove(_HideFlyout);

		_Flyout.Tabs.ForEach(tab => tab.NotActive());
	}
}