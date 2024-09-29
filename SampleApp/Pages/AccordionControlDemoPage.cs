using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class AccordionControlDemoPage : ContentPage
{
	#region ACCORDION
	private readonly AccordionControl _Top = new AccordionControl()
		.Stroke(Colors.Purple)
		.StrokeShape(new RoundRectangle().CornerRadius(5,5,0,0))
		.Header(new Label().Text("Header").FontSize(18).Padding(8))
		.AccordionContent(new Label().Text("Some long form content perhaps").FontSize(14).Padding(8));
	private readonly AccordionControl _Middle = new AccordionControl()
		.Margin(0, -1, 0, -1)
		.Stroke(Colors.SlateGray)
		.StrokeShape(new RoundRectangle().CornerRadius(0))
		.Header(new Label().Text("Header").FontSize(18).Padding(8))
		.AccordionContent(new Label().Text("Some long form content perhaps").FontSize(14).Padding(8));
	private readonly AccordionControl _Bottom = new AccordionControl()
		.Stroke(Colors.Blue)
		.StrokeShape(new RoundRectangle().CornerRadius(0,0,5,5))
		.Header(new Label().Text("Header").FontSize(18).Padding(8))
		.AccordionContent(new Label().Text("Some long form content perhaps").FontSize(14).Padding(8));
	#endregion

	#region Constructor
	public AccordionControlDemoPage()
	{
		this
		.Title("Accordion Control")
		.Content(
			new VerticalStackLayout()
			.Children([
				new VerticalStackLayout()
					.Spacing(0)
					.Children([
						_Top,
						_Middle,
						_Bottom
					]),
				new AccordionControl()
					.Stroke(Colors.DarkGray)
					.StrokeShape(new RoundRectangle().CornerRadius(0))
					.Header(new Label().Text("No Corners!").FontSize(18).Padding(8))
					.AccordionContent(new Label().Text("Some long form content perhaps").FontSize(14).Padding(8))
			])
			.Padding(16)
			.Spacing(16));
	}
	#endregion
}