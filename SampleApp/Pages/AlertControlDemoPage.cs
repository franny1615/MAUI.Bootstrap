using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class AlertControlDemoPage : ContentPage
{
	#region ALERTS
	private readonly AlertControl _PrimaryNonDismissable = new AlertControl()
		.NotDismissable()
		.AlertContent(new Label()
			.Text("Will be gone in 3 seconds").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
		.Danger()
		.Timeout(TimeSpan.FromMilliseconds(3000));
	private readonly AlertControl _Primary = new AlertControl()
		.Dismissable()
		.AlertContent(new Label()
			.Text("Content can be anything.").FontSize(14)
			.FontAttributes(FontAttributes.Bold).Padding(8)
			.TextColor(Colors.White))
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

	private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout()
		.Padding(0)
		.Spacing(16);

	#region Constructor
	public AlertControlDemoPage()
	{
		_ContentLayout.Children([
			_PrimaryNonDismissable,
			_Primary,
			_Secondary,
			_Success,
			_Danger,
			_Warning,
			_Info,
			_Light,
			_Dark,
		]);

		this
		.Title("Alert Control")
		.Content(new VerticalStackLayout()
			.Spacing(16)
			.Padding(16)
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
				_ContentLayout
			]));

		_PrimaryNonDismissable.CloseClicked += RemoveAlert;
		_Primary.CloseClicked += RemoveAlert;
		_Secondary.CloseClicked += RemoveAlert;
		_Success.CloseClicked += RemoveAlert;
		_Danger.CloseClicked += RemoveAlert;
		_Warning.CloseClicked += RemoveAlert;
		_Info.CloseClicked += RemoveAlert;
		_Light.CloseClicked += RemoveAlert;
		_Dark.CloseClicked += RemoveAlert;

		_ContentLayout.PrimaryAlert(
			new Label()
				.Text("Injected into VStack")
				.CenterVertical()
				.Padding(4)
				.TextColor(Colors.White)
		);

		_ContentLayout.PrimaryAlert(
			new Label()
				.Text("Injected into VStack, gone in 1 second")
				.CenterVertical()
				.Padding(4)
				.TextColor(Colors.White),
			false,
			1000 // ms
		);
	}
	#endregion

	#region Methods
	private void RemoveAlert(object? sender, EventArgs e)
	{
		if (sender is AlertControl control)
		{
			_ContentLayout.Remove(control);
		}
	}
	#endregion
}