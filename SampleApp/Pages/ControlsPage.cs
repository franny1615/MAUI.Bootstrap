using FmgLib.MauiMarkup;
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
								.OnClicked((s, e) => {
									Navigation.PushAsync(new AccordionControlDemoPage());
								}),
							new Button()
								.Text("Alert")
								.OnClicked((s, e) => {
									Navigation.PushAsync(new AlertControlDemoPage());
								}),
							new Button()
								.Text("Badge")
								.OnClicked((s, e) => {
									Navigation.PushAsync(new BadgeControlDemoPage());
								}),
							new Button()
								.Text("Breadcrumb")
								.OnClicked((s, e) => {
									Navigation.PushAsync(new BreadcrumbControlDemoPage());
								})
						])));
	}
}