using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class BreadcrumbControlDemoPage : ContentPage
{
	public BreadcrumbControlDemoPage()
	{
		var stepOne = new Label().Text("Step One").Center();
		var stepTwo = new Label().Text("Step Two").Center();
		var stepThree = new Label().Text("Step Three").Center();
		var grid = new Grid().HeightRequest(150);
		grid.Add(stepOne);

		this
		.Title("Breadcrumb Control")
		.Content(new VerticalStackLayout()
			.Padding(16)
			.Spacing(16)
			.Children([
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
				new Button()
					.Text("One more page")
					.OnClicked((s, e) => 
					{
						Navigation.PushAsync(new BreadcrumbControlDemoPage2());
					}),
				new BreadcrumbControl()
					.Routes([
						new Breadcrumb()
							.Name("Step One")
							.Selected(), 
						new Breadcrumb().Name("Step Two"), 
						new Breadcrumb().Name("Step Three")])
					.OnRouteClicked((s, e) => 
					{
						grid.Clear();
						if (e.SelectedRoute == "Step One")
							grid.Add(stepOne);
						else if (e.SelectedRoute == "Step Two")
							grid.Add(stepTwo);
						else if (e.SelectedRoute == "Step Three")
							grid.Add(stepThree);
					}),
				grid
			]));
	}
}

public class BreadcrumbControlDemoPage2 : ContentPage
{
	public BreadcrumbControlDemoPage2()
	{
		this
		.Title("Breadcrumb Control 2")
		.Content(new VerticalStackLayout()
			.Padding(16)
			.Spacing(16)
			.Children([
				new BreadcrumbControl()
					.Routes([
						new Breadcrumb().Name("Controls Page"), 
						new Breadcrumb().Name("Breadcrumb Control"), 
						new Breadcrumb()
							.Name(Title)
							.Selected()])
					.OnRouteClicked((s, e) => 
					{
						if (e.SelectedRoute == "Controls Page")
						{
							Navigation.PopAsync();
							Navigation.PopAsync();
						}
						else if (e.SelectedRoute == "Breadcrumb Control")
						{
							Navigation.PopAsync();
						}
					}),
			]));
	}
}