using FmgLib.MauiMarkup;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Layouts;

namespace SampleApp.Pages;

public class CollapseStylesDemoPage : ContentPage
{
	public CollapseStylesDemoPage()
	{ 
		var collapseItem = new Border()
			.Card()
			.Content(new Label()
				.Text("... 0_0 ...")
				.CardTitle()
				.Center());
		var collapseLayout = new Grid()
			.IsVisible(false)
			.Children([
				collapseItem
			]);
		var collapseItem2 = new Border()
			.Card()
			.IsVisible(false)
			.AlignLeft()
			.HeightRequest(90)
			.Content(new Label()
				.Text("... 0_0 ...")
				.CardTitle()
				.Center());
		var basic = new Border()
			.Card()
			.IsVisible(false)
			.AlignLeft()
			.Content(new Label()
				.Text("... 0_0 ...")
				.CardTitle()
				.Center());
		this
		.Title("Collapse Styles")
		.Content(
			new VerticalStackLayout()
				.Padding(16)
				.Spacing(16)
				.Children([
					new Button()
						.Primary()
						.Text("Toggle Collapse")
						.OnClicked((s,e) => {
							collapseLayout.Collapse(90);
						}),
					collapseLayout,
					new Button()
						.Primary()
						.Text("Toggle Width Collapse")
						.OnClicked((s,e) => {
							Collapse.CollapseWidthAnimate(
								collapseItem2,
								120
							);
						}),
					collapseItem2,
					basic,
					new Button()
						.Primary()
						.Text("Basic Toggle")
						.OnClicked((s, e) => {
							basic.IsVisible = !basic.IsVisible;
						})
				])
		);
	}
}