using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class ControlsPage : ContentPage
{	
	public ControlsPage()
	{
		this
		.Title("Controls Dashboard")
		.Content(
			new ScrollView()
				.Content(
					new VerticalStackLayout()
						.Spacing(16)
						.Padding(16)
						.Children([
							new BreadcrumbControl()
								.Routes([
									new Breadcrumb()
										.Name(Title)
										.Selected()
								]),
							new Button()
								.Text("Accordion")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new AccordionControlDemoPage());
								}),
							new Button()
								.Text("Alert")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new AlertControlDemoPage());
								}),
							new Button()
								.Text("Badge")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new BadgeControlDemoPage());
								}),
							new Button()
								.Text("Breadcrumb")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new BreadcrumbControlDemoPage());
								}),
							new Button()
								.Text("Button")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new ButtonStylesDemoPage());
								}),
							new Button()
								.Text("Cards")
								.Primary()
								.OnClicked((s, e) => {
									Navigation.PushAsync(new CardStylesDemoPage());
								}),
							new Button()
								.Text("Toggle Theme")
								.Danger()
								.OnClicked((s, e) => {
									switch (BootstrapColors.CurrentTheme)
									{
										case AppTheme.Dark:
											BootstrapColors.CurrentTheme = AppTheme.Light;
											break;
										case AppTheme.Light:
											BootstrapColors.CurrentTheme = AppTheme.Dark;
											break;
									}
                                }),
							new Button()
								.Text("Set Page Color To Pink")
								.Info()
								.OnClicked((s,e) => {
									BootstrapColors.PageColor = Colors.Pink;
								})
						])));
    }
}