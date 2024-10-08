using System.Globalization;
using CommunityToolkit.Maui.Alerts;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Layouts;

namespace SampleApp.Pages;

public class BadgeControlDemoPage : ContentPage
{
	#region Simple BadgeControl
	private readonly BadgeControl _BadgeControl1 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(32);
	private readonly BadgeControl _BadgeControl2 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(24);
	private readonly BadgeControl _BadgeControl3 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(16);
	private readonly BadgeControl _BadgeControl4 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(8);
	#endregion

	private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout()
		.Padding(16)
		.Spacing(16);

	#region Constructor
	public BadgeControlDemoPage()
	{
		this
		.Title("Badge Control")
		.Content(_ContentLayout);

		_ContentLayout.Children([
			new BreadcrumbControl()
				.Routes([
					new Breadcrumb().Name("Controls Page"), 
					new Breadcrumb()
						.Name(Title)
						.Selected()])
				.OnRouteClicked((s, e) => 
				{
					if (e.SelectedRoute == "Controls Page")
					{
						Navigation.PopAsync();
					}
				}),
			_BadgeControl1.AlignLeft(),
			_BadgeControl2.AlignLeft(),
			_BadgeControl3.AlignLeft(),
			_BadgeControl4.AlignLeft(),
			new FlexLayout()
				.Direction(FlexDirection.Row)
				.Wrap(FlexWrap.Wrap)
				.JustifyContent(FlexJustify.Center)
				.Children([
					new BadgeControl()
						.Margin(2)
						.Text("Primary")
						.Primary(),
					new BadgeControl()
						.Margin(2)
						.Text("Secondary")
						.Secondary(),
					new BadgeControl()
						.Margin(2)
						.Text("Success")
						.Success(),
					new BadgeControl()
						.Margin(2)
						.Text("Info")
						.Info(),
					new BadgeControl()
						.Margin(2)
						.Text("Warning")
						.Warning(),
					new BadgeControl()
						.Margin(2)
						.Text("Danger")
						.Danger(),
					new BadgeControl()
						.Margin(2)
						.Text("Light")
						.Light(),
					new BadgeControl()
						.Margin(2)
						.Text("Dark")
						.Dark(),
				]),
			new FlexLayout()
				.Direction(FlexDirection.Row)
				.Wrap(FlexWrap.Wrap)
				.JustifyContent(FlexJustify.Center)
				.Children([
					new BadgeControl()
						.Margin(2)
						.Text("Primary")
						.Primary()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Secondary")
						.Secondary()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Success")
						.Success()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Info")
						.Info()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Warning")
						.Warning()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Danger")
						.Danger()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Light")
						.Light()
						.Rounded(),
					new BadgeControl()
						.Margin(2)
						.Text("Dark")
						.Dark()
						.Rounded(),
				]),
				new BoxView().MakeDivider(Colors.DarkGray),
				new Grid()
					.HorizontalOptions(LayoutOptions.Start)
					.Children([
						new Button()
							.Text("Primary")
							.Margin(0,8,12,8)
							.Primary()
							.HorizontalOptions(LayoutOptions.Center)
							.VerticalOptions(LayoutOptions.Center)
							.OnClicked((s,e) => {
								Toast.Make("Yay").Show();
							}),
						new BadgeControl()
							.HeightRequest(20)
							.WidthRequest(20)
							.Stroke(Colors.White)
							.VerticalOptions(LayoutOptions.Start)
							.HorizontalOptions(LayoutOptions.End)
							.Danger()
							.Rounded()
					]),
				new Grid()
					.HorizontalOptions(LayoutOptions.Start)
					.Children([
						new Button()
							.Text("Primary")
							.Margin(0,8,12,8)
							.Primary()
							.HorizontalOptions(LayoutOptions.Center)
							.VerticalOptions(LayoutOptions.Center)
							.OnClicked((s,e) => {
								Toast.Make("Yay 2").Show();
							}),
						new BadgeControl()
							.Text("99+")
							.TextSize(13)
							.VerticalOptions(LayoutOptions.Start)
							.HorizontalOptions(LayoutOptions.End)
							.Danger()
							.Rounded()
					]),
		]);

		_ContentLayout.Add(new Button()
			.Warning()
			.Text("Toggle Language")
			.Center()
			.OnClicked((s, e) => 
			{
				if (Translator.Instance.CurrentCulture.TwoLetterISOLanguageName == "en")
				{
					Translator.Instance.ChangeCulture(CultureInfo.GetCultureInfo("es-ES"));
				}
				else 
				{
					Translator.Instance.ChangeCulture(CultureInfo.GetCultureInfo("en-US"));
				}
			}));
	}
	#endregion
}