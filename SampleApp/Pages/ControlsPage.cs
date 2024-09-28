using System.Globalization;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace SampleApp.Pages;

public class ControlsPage : ContentPage
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

	#region ALERTS
	private readonly Label _PrimaryContent = new Label()
		.Text(e => e.Translate("Hello")).FontSize(14)
		.FontAttributes(FontAttributes.Bold).Padding(8)
		.TextColor(Colors.White);
	private readonly AlertControl _Primary = new AlertControl()
		.Dismissable()
		.Primary();
	private readonly AlertControl _Secondary = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
		.Secondary();
	private readonly AlertControl _Success = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
		.Success();
	private readonly AlertControl _Danger = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
		.Danger();
	private readonly AlertControl _Warning = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.Black))
		.Warning();
	private readonly AlertControl _Info = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.Blue))
		.Info();
	private readonly AlertControl _Light = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.Black))
		.Light();
	private readonly AlertControl _Dark = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
		.Dark();
	#endregion

	#region Simple BadgeControl
	private readonly BadgeControl _BadgeControl1 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(32);
	private readonly BadgeControl _BadgeControl2 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(24);
	private readonly BadgeControl _BadgeControl3 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(16);
	private readonly BadgeControl _BadgeControl4 = new BadgeControl()
		.Text(e => e.Translate("Hello"))
		.TextSize(8);
	#endregion

	private readonly VerticalStackLayout _ContentLayout;

	public ControlsPage()
	{
		Title = "Controls Page";

		_Primary.AlertContent(_PrimaryContent);

		_ContentLayout = new VerticalStackLayout()
			.Padding(8)
			.Spacing(16)
			.Children([
				new VerticalStackLayout()
					.Spacing(0)
					.Children([
						_Top,
						_Middle,
						_Bottom,
					]),
				_Primary,
				_Secondary,
				_Success,
				_Danger,
				_Warning,
				_Info,
				_Light,
				_Dark,
				new VerticalStackLayout()
					.Spacing(2)
					.Children([
						_BadgeControl1.AlignLeft(),
						_BadgeControl2.AlignLeft(),
						_BadgeControl3.AlignLeft(),
						_BadgeControl4.AlignLeft(),
						new FlexLayout()
							.Direction(FlexDirection.Row)
							.Wrap(FlexWrap.Wrap)
							.JustifyContent(FlexJustify.Center)
							.Children([
								new BadgeControl()
									.Margin(2)
									.Text("Primary")
									.Primary(),
								new BadgeControl()
									.Margin(2)
									.Text("Secondary")
									.Secondary(),
								new BadgeControl()
									.Margin(2)
									.Text("Success")
									.Success(),
								new BadgeControl()
									.Margin(2)
									.Text("Info")
									.Info(),
								new BadgeControl()
									.Margin(2)
									.Text("Warning")
									.Warning(),
								new BadgeControl()
									.Margin(2)
									.Text("Danger")
									.Danger(),
								new BadgeControl()
									.Margin(2)
									.Text("Light")
									.Light(),
								new BadgeControl()
									.Margin(2)
									.Text("Dark")
									.Dark(),
							]),
						new FlexLayout()
							.Direction(FlexDirection.Row)
							.Wrap(FlexWrap.Wrap)
							.JustifyContent(FlexJustify.Center)
							.Children([
								new BadgeControl()
									.Margin(2)
									.Text("Primary")
									.Primary()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Secondary")
									.Secondary()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Success")
									.Success()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Info")
									.Info()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Warning")
									.Warning()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Danger")
									.Danger()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Light")
									.Light()
									.Rounded(),
								new BadgeControl()
									.Margin(2)
									.Text("Dark")
									.Dark()
									.Rounded(),
							])
					])
			]);
		this.Content(
			new ScrollView()
				.Content(_ContentLayout)
		);

		_Primary.CloseClicked += RemoveAlert;
		_Secondary.CloseClicked += RemoveAlert;
		_Success.CloseClicked += RemoveAlert;
		_Danger.CloseClicked += RemoveAlert;
		_Warning.CloseClicked += RemoveAlert;
		_Info.CloseClicked += RemoveAlert;
		_Light.CloseClicked += RemoveAlert;
		_Dark.CloseClicked += RemoveAlert;

		_ContentLayout.PrimaryAlert(new Label()
			.Text("some text")
			.CenterVertical()
			.Padding(4)
			.TextColor(Colors.White));

		_ContentLayout.Add(new Button()
			.Text("Toggle Language")
			.Center()
			.OnClicked((s, e) => 
			{
				if (Translator.Instance.CurrentCulture.TwoLetterISOLanguageName == "en")
				{
					Translator.Instance.ChangeCulture(CultureInfo.GetCultureInfo("es-ES"));
				}
				else 
				{
					Translator.Instance.ChangeCulture(CultureInfo.GetCultureInfo("en-US"));
				}
			}));
	}

    private void RemoveAlert(object? sender, EventArgs e)
	{
		if (sender is AlertControl control)
		{
			_ContentLayout.Remove(control);
		}
	}
}