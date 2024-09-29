using FmgLib.MauiMarkup;
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
								})
						])));
	}
}