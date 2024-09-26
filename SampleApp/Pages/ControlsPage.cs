using CommunityToolkit.Maui.Markup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Utilities;
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

	#region ALERTS
	private readonly AlertControl _Primary = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.White),
		AlertType = AlertType.Primary,
	};
	private readonly AlertControl _Secondary = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.White),
		AlertType = AlertType.Secondary,
	};
	private readonly AlertControl _Success = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.White),
		AlertType = AlertType.Success,
	};
	private readonly AlertControl _Danger = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.White),
		AlertType = AlertType.Danger,
	};
	private readonly AlertControl _Warning = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.Black),
		AlertType = AlertType.Warning,
	};
	private readonly AlertControl _Info = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.Blue),
		AlertType = AlertType.Info,
	};
	private readonly AlertControl _Light = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.Black),
		AlertType = AlertType.Light,
	};
	private readonly AlertControl _Dark = new()
	{
		Dismissable = true,
		AlertContent = new Label().Text("Content can be anything.").FontSize(14).Bold().Padding(8).TextColor(Colors.White),
		AlertType = AlertType.Dark,
	};
	#endregion

	public ControlsPage()
	{
		Title = "Controls Page";

		var layout = new VerticalStackLayout
		{
			Padding = 8,
			Spacing = 16,
			Children = 
			{
				new VerticalStackLayout
				{
					Spacing = 0,
					Children = 
					{
						_Top,
						_Middle,
						_Bottom,
					}
				},
				_Primary,
				_Secondary,
				_Success,
				_Danger,
				_Warning,
				_Info,
				_Light,
				_Dark
			}
		};

		Content = layout;

		_Primary.CloseClicked += RemoveAlert;
		_Secondary.CloseClicked += RemoveAlert;
		_Success.CloseClicked += RemoveAlert;
		_Danger.CloseClicked += RemoveAlert;
		_Warning.CloseClicked += RemoveAlert;
		_Info.CloseClicked += RemoveAlert;
		_Light.CloseClicked += RemoveAlert;
		_Dark.CloseClicked += RemoveAlert;

		layout.PrimaryAlert(new Label().Text("some text").TextColor(Colors.White));
	}

	private void RemoveAlert(object? sender, EventArgs e)
	{
		if (sender is AlertControl control && Content is VerticalStackLayout layout)
		{
			layout.Remove(control);
		}
	}
}