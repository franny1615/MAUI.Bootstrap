using CommunityToolkit.Maui.Alerts;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Extensions;
using MAUIBootstrap.Pages;

namespace SampleApp.Pages;

public class ModalDemoPage : ContentPage
{
	public ModalDemoPage()
	{
		this
			.Title("Modals")
			.Content(new VerticalStackLayout()
				.Spacing(16)
				.Padding(16)
				.Center()
				.Children([
					new Button()
						.Primary()
						.Text("Default Modal | Close Button")
						.OnClicked((s,e) => {
							Navigation.PushModalAsync(
								new ModalPage()
									.ModalHeader(new Label()
										.Text("Modal Title")
										.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
										.FontSize(32)
										.VerticalTextAlignment(TextAlignment.Center)
									)
									.Body(new Label()
										.Text("This is some basic modal body, but this can be anything that inherits from View.")
									)
									.OnClosed((s,e) => {
										Toast.Make("Modal Closed").Show();
									})
							);
						}),
					new Button()
						.Primary()
						.Text("Fullscreen Modal")
						.OnClicked((s,e) => {
							Navigation.PushModalAsync(
								new ModalPage()
									.IsFullScreen(true)
									.ModalHeader(new Label()
										.Text("Modal Title")
										.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
										.FontSize(32)
										.VerticalTextAlignment(TextAlignment.Center)
									)
									.Body(new Label()
										.Text("This is some basic modal body, but this can be anything that inherits from View.")
									)
									.OnClosed((s,e) => {
										Toast.Make("Modal Closed").Show();
									})
							);
						}),
					new Button()
						.Primary()
						.Text("Default Modal | No Close Button")
						.OnClicked((s,e) => {
							Navigation.PushModalAsync(
								new ModalPage()
									.IsCloseVisible(false)
									.Assign(out var modal2)
									.ModalHeader(new Label()
										.Text("Modal Title")
										.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
										.FontSize(32)
										.VerticalTextAlignment(TextAlignment.Center)
									)
									.Body(new VerticalStackLayout()
										.Spacing(8)
										.Children([
											new Label()
												.Text("This is some basic modal body, but this can be anything that inherits from View."),
											new Button()
												.Secondary()
												.Text("Close Manually")
												.OnClicked((s,e) => {
													modal2.ManualClose();
												})
										])
									)
									.OnClosed((s,e) => {
										Toast.Make("Modal Closed").Show();
									})
							);
						})
				]));
	}
}