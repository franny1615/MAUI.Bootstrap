using CommunityToolkit.Maui.Alerts;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Platform;

namespace SampleApp.Pages;

public class ButtonStylesDemoPage : ContentPage
{
	public ButtonStylesDemoPage()
	{
		var btn1 = new Button()
			.Text("Test Button")
			.Primary();
		var btn2 = new Button()
			.Text("Text Button Outline")
			.Primary()
			.Outlined();

		this
		.Title("Button Styles")
		.Content(new ScrollView()
			.Padding(16)
			.Content(new VerticalStackLayout()
				.Spacing(16)
				.Children([
					new BreadcrumbControl()
						.Routes([
							new Breadcrumb().Name("Controls Page"),
							new Breadcrumb()
								.Name(Title)
								.Selected(),
						])
						.OnRouteClicked((s, e) => {
							if (e.SelectedRoute == "Controls Page") {
								Navigation.PopAsync();
							}
						}),
						new Button()
							.Text("Primary")
							.Primary()
							.AlignLeft(),
						new Button()
							.Text("Secondary")
							.Secondary()
							.AlignLeft(),
						new Button()
							.Text("Success")
							.Success()
							.AlignLeft(),
						new Button()
							.Text("Info")
							.Info()
							.AlignLeft(),
						new Button()
							.Text("Warning")
							.Warning()
							.AlignLeft(),
						new Button()
							.Text("Danger")
							.Danger()
							.AlignLeft(),
						new Button()
							.Text("Light")
							.Light()
							.AlignLeft(),
						new Button()
							.Text("Dark")
							.Dark()
							.AlignLeft(),
						new Button()
							.Text("Link")
							.Link()
							.AlignLeft(),
						new Button()
							.Text("Primary")
							.Primary()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Secondary")
							.Secondary()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Success")
							.Success()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Info")
							.Info()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Warning")
							.Warning()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Danger")
							.Danger()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Light")
							.Light()
							.Outlined()
							.AlignLeft(),
						new Button()
							.Text("Dark")
							.Dark()
							.Outlined()
							.AlignLeft(),
						new BoxView().MakeDivider(Colors.DarkGray),
						btn1,
						btn2,
						new Button()
							.Text("Toggle Enable/Disable State")
							.Danger()
							.OnClicked((s, e) => {
								if (btn1.IsEnabled) 
									btn1.Disabled();
								else
									btn1.Enabled();
								
								if (btn2.IsEnabled) 
									btn2.Disabled();
								else
									btn2.Enabled();
							}),
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
						new BoxView().MakeDivider(Colors.DarkGray),
						new HorizontalStackLayout()
							.Spacing(0)
							.Children([
								new Button()
									.Text("Primary")
									.Primary()
									.SharpCorners()
									.OnClicked((s,e) => Toast.Make("Primary").Show()),
								new Button()
									.Text("Danger")
									.Danger()
									.SharpCorners()
									.OnClicked((s,e) => Toast.Make("Danger").Show()),
								new Button()
									.Text("Warning")
									.Warning()
									.SharpCorners()
									.OnClicked((s,e) => Toast.Make("Warning").Show()),
							]),
						new BoxView().MakeDivider(Colors.DarkGray),
						new Label().Text("Radio Button").FontAttributes(FontAttributes.Bold),
						new HorizontalStackLayout()
							.Spacing(8)
							.Children([
								new RadioButton()
									.Bootstrap(
										BootstrapColors.PrimaryShade, 
										BootstrapColors.Primary)
									.Content(new Label()
										.Text("Option A")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center)),
								new RadioButton()
									.Bootstrap(
										BootstrapColors.PrimaryShade, 
										BootstrapColors.Primary)
									.Content(new Label()
										.Text("Option B")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center)),
								new RadioButton()
									.Bootstrap(
										BootstrapColors.PrimaryShade, 
										BootstrapColors.Primary)
									.Content(new Label()
										.Text("Option C")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center)),
							]),
						new BoxView().MakeDivider(Colors.DarkGray),
						new Label().Text("Checkbox").FontAttributes(FontAttributes.Bold),
						new FlexLayout()
							.Direction(FlexDirection.Row)
							.Wrap(FlexWrap.Wrap)
							.Children([
								new CheckboxControl()
									.Primary()
									.Margin(2)
									.Content(new Label()
										.Text("Primary")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Secondary()
									.Margin(2)
									.Content(new Label()
										.Text("Secondary")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Success()
									.Margin(2)
									.Content(new Label()
										.Text("Success")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Warning()
									.Margin(2)
									.Content(new Label()
										.Text("Warning")
										.TextColor(Colors.Black)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Danger()
									.Margin(2)
									.Content(new Label()
										.Text("Danger")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Info()
									.Margin(2)
									.Content(new Label()
										.Text("Info")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Light()
									.Margin(2)
									.Content(new Label()
										.Text("Light")
										.TextColor(Colors.Black)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
								new CheckboxControl()
									.Dark()
									.Margin(2)
									.Content(new Label()
										.Text("Dark")
										.TextColor(Colors.White)
										.VerticalOptions(LayoutOptions.Center))
									.OnCheckedChanged((s, e) => { 
										string isChecked = ((CheckboxControl)s!).IsChecked ? "Checked" : "Unchecked";
										Toast.Make(isChecked).Show(); 
									}),
							])
				])
			));
	}
}