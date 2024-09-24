using CommunityToolkit.Maui.Markup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace SampleApp.Pages;

public class ControlsPage : ContentPage
{
	#region ACCORDION
	private readonly AccordionControl _Top = new()
	{
		Stroke = Colors.Purple,
		StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(5,5,0,0) },
		Header = new Label().Text("Header").FontSize(18).Padding(8),
		AccordionContent = new Label().Text("Some long form content perhaps").FontSize(14).Padding(8),
	};
	private readonly AccordionControl _Middle = new()
	{
		Margin = new Thickness(0,-1,0,-1),
		Stroke = Colors.SlateGray,
		StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(0) },
		Header = new Label().Text("Header").FontSize(18).Padding(8),
		AccordionContent = new Label().Text("Some long form content perhaps").FontSize(14).Padding(8),
	};
	private readonly AccordionControl _Bottom = new()
	{
		Stroke = Colors.Blue,
		StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(0,0,5,5) },
		Header = new Label().Text("Header").FontSize(18).Padding(8),
		AccordionContent = new Label().Text("Some long form content perhaps").FontSize(14).Padding(8),
	};
	#endregion

	public ControlsPage()
	{
		Title = "Controls Page";
		Content = new VerticalStackLayout
		{
			Padding = 8,
			Spacing = 0,
			Children = 
			{
				_Top,
				_Middle,
				_Bottom
			}
		};
	}
}