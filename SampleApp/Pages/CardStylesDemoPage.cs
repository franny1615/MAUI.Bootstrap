using CommunityToolkit.Maui.Alerts;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace SampleApp.Pages;

public class CardStylesDemoPage : ContentPage
{
	public CardStylesDemoPage()
	{
		this
		.Title("Card Styles")
		.Content(
			new VerticalStackLayout()
				.Margin(8)
				.Children([
					new Border()
						.Card()
						.Content(
							new VerticalStackLayout()
								.Spacing(0)
								.Children([
									new Image()
										.Source("https://picsum.photos/200/300")
										.CardImage(),
									new Label()
										.Text("Card Title")
										.CardTitle(),
									new Label()
										.Text("Some quick example text to build on the card title and make up the bulk of the card's content.")
										.CardSubtitle(),
									new Button()
										.Text("Go somewhere")
										.Primary()
										.CardAction()
										.OnClicked((s, e) => {
											Toast.Make("Hello").Show();
										})
								])
						)
				])
		);
	}
}