using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.CSS;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls.StyleSheets;

namespace SampleApp.Pages;

public class ListGroupStylesDemoPage : ContentPage
{
	#region SIMPLE
	private readonly Label _LabelOne = new Label()
		.Text("Tap Me!")
		.Padding(8)
		.FillHorizontal()
		.HorizontalTextAlignment(TextAlignment.Center);
	private readonly Label _LabelTwo = new Label()
		.Text("Tap Me!")
		.Padding(8)
		.FillHorizontal()
		.HorizontalTextAlignment(TextAlignment.Center);
	private readonly Label _LabelThree = new Label()
		.Text("Tap Me!")
		.Padding(8)
		.FillHorizontal()
		.HorizontalTextAlignment(TextAlignment.Center);
	private readonly Border _Border = new Border()
		.ListGroup();
	#endregion

	#region COMPLEX
	private readonly VerticalStackLayout _Complex1 = new VerticalStackLayout();
	private readonly VerticalStackLayout _Complex2 = new VerticalStackLayout();
	private readonly VerticalStackLayout _Complex3 = new VerticalStackLayout().IsEnabled(false);
	private readonly Label _HeaderLabel = new Label()
		.Text("Header")
		.Padding(8)
		.FillHorizontal()
		.FontSize(15)
		.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _Subtitle = new Label()
		.Text("This would be subtitle text")
		.Padding(8)
		.FillHorizontal()
		.FontSize(13)
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _HeaderLabel2 = new Label()
		.Text("Header")
		.Padding(8)
		.FillHorizontal()
		.FontSize(15)
		.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _Subtitle2 = new Label()
		.Text("This would be subtitle text")
		.Padding(8)
		.FillHorizontal()
		.FontSize(13)
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _HeaderLabel3 = new Label()
		.Text("Header")
		.Padding(8)
		.FillHorizontal()
		.FontSize(15)
		.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance))
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _Subtitle3 = new Label()
		.Text("This would be subtitle text")
		.Padding(8)
		.FillHorizontal()
		.FontSize(13)
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Border _BorderComplex = new Border()
		.ListGroup();
	#endregion

	public ListGroupStylesDemoPage()
	{
		using (var reader = new StringReader(BootstrapCSS.Styles))
        {
            Resources.Add(StyleSheet.FromReader(reader));
        }

		#region SIMPLE
		_Border.Content(new VerticalStackLayout()
			.Children([
				_LabelOne,
				new BoxView().Divider(),
				_LabelTwo,
				new BoxView().Divider(),
				_LabelThree
			]));
		_LabelOne.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s,e) => {
					UI.Active(_LabelOne);
				})
		]);
		_LabelTwo.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s,e) => {
					UI.Active(_LabelTwo);
				})
		]);
		_LabelThree.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s,e) => {
					UI.Active(_LabelThree);
				})
		]);
		#endregion

		#region COMPLEX
		_Complex1.Children([
			new Grid()
				.ColumnDefinitions(e => e.Star().Auto())
				.Children([
					_HeaderLabel.Column(0),
					new Label()
						.BackgroundColor(BootstrapColors.Light)
						.Padding(8)
						.Text("Secondary")
						.TextColor(Colors.Black)
						.Column(1)
				]),
			_Subtitle
		]).GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s, e) => {
					UI.Active(_Complex1);
				})
		]);
		_Complex2.Children([
			_HeaderLabel2,
			_Subtitle2
		]).GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s, e) => {
					UI.Active(_Complex2);
				})
		]);
		_Complex3.Children([
			_HeaderLabel3,
			_Subtitle3
		]).GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s, e) => {
					UI.Active(_Complex3);
				})
		]);
		_BorderComplex.Content(new VerticalStackLayout().Children([
			_Complex1,
			new BoxView().Divider(),
			_Complex2,
			new BoxView().Divider(),
			_Complex3,
		]));
		#endregion

		this
			.Title("List Groups")
			.Content(new VerticalStackLayout()
				.Padding(16)
				.Children([
					_Border,
					new BoxView().Divider().Margin(16),
					_BorderComplex
				]));
	}
}