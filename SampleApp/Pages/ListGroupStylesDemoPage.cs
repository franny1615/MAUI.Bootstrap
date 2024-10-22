using System.Globalization;
using System.Runtime.CompilerServices;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.CSS;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls.StyleSheets;
using SampleApp.ViewModels;

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

	public ListGroupStylesDemoPage(ListGroupViewModel viewModel)
	{
		BindingContext = viewModel;

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

		#region HORIZONTAL
		var horizontalListGroup = new Border()
			.ListGroup()
			.Content(new Grid()
				.ColumnDefinitions(e => e.Star().Auto().Star().Auto().Star())
				.Children([
					new Label()
						.Text("Item 1")
						.Padding(4)
						.Column(0)
						.Center(),
					new BoxView().VerticalDivider().Column(1),
					new Label()
						.Text("Item 2")
						.Padding(4)
						.Column(2)
						.Center(),
					new BoxView().VerticalDivider().Column(3),
					new Label()
						.Text("Item 3")
						.Padding(4)
						.Column(4)
						.Center(),
				]));
		#endregion

		#region VERIANTS
		var primaryVariant = new Label()
			.Text("Primary variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		primaryVariant.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped((s,e) => {
					UI.PrimarySubtle(primaryVariant);
				})
		]);
		UI.PrimarySubtle(primaryVariant);
		var secondaryVariant = new Label()
			.Text("Secondary variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.SecondarySubtle(secondaryVariant);
		var successVariant = new Label()
			.Text("success variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.SuccessSubtle(successVariant);
		var warningVariant = new Label()
			.Text("Warning variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.WarningSubtle(warningVariant);
		var dangerVariant = new Label()
			.Text("Danger variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.DangerSubtle(dangerVariant);
		var infoVariant = new Label()
			.Text("Info variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.InfoSubtle(infoVariant);
		var lightVariant = new Label()
			.Text("Light variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.LightSubtle(lightVariant);
		var darkVariant = new Label()
			.Text("Dark variant style")
			.FillBothDirections()
			.VerticalTextAlignment(TextAlignment.Center)
			.HorizontalTextAlignment(TextAlignment.Center)
			.Padding(8);
		UI.DarkSubtle(darkVariant);
		var variantListGroup = new Border()
			.ListGroup()
			.Content(new VerticalStackLayout()
				.Children([
					primaryVariant,
					new BoxView().Divider(),
					secondaryVariant,
					new BoxView().Divider(),
					successVariant,
					new BoxView().Divider(),
					warningVariant,
					new BoxView().Divider(),
					dangerVariant,
					new BoxView().Divider(),
					infoVariant,
					new BoxView().Divider(),
					lightVariant,
					new BoxView().Divider(),
					darkVariant,
				]));
		#endregion

		#region WITH BADGES
		var badgesInListGroups = new Border()
			.ListGroup()
			.Content(new VerticalStackLayout()
				.Children([
					new Grid()
						.ColumnDefinitions(e => e.Star().Auto())
						.Children([
							new Label()
								.Text("Item 1")
								.Column(0)
								.Padding(4)
								.VerticalTextAlignment(TextAlignment.Center)
								.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance)),
							new BadgeControl()
								.Column(1)
								.Text("14")
								.TextSize(13)
								.Primary()
								.Rounded()
								.Margin(4)
						]),
					new BoxView().Divider(),
					new Grid()
						.ColumnDefinitions(e => e.Star().Auto())
						.Children([
							new Label()
								.Text("Item 2")
								.Column(0)
								.Padding(4)
								.VerticalTextAlignment(TextAlignment.Center)
								.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance)),
							new BadgeControl()
								.Column(1)
								.Text("2")
								.TextSize(13)
								.Primary()
								.Rounded()
								.Margin(4)
						]),
				])
			);
		#endregion

		#region Radios in List Group
		var radioListGroups = new Border()
			.ListGroup()
			.Content(new VerticalStackLayout()
				.Children([
					new RadioButton()
						.Bootstrap()
						.Content("Item 1"),
					new BoxView().Divider(),
					new RadioButton()
						.Bootstrap()
						.Content("Item 2"),
					new BoxView().Divider(),
					new RadioButton()
						.Bootstrap()
						.Content("Item 3"),
				]));
		#endregion

		#region Checkboxes in List Group
		var checkboxListGroup = new Border()
			.ListGroup()
			.Content(new VerticalStackLayout()
				.Children([
					new Grid()
						.ColumnDefinitions(e => e.Auto().Star())
						.Children([
							new CheckBox().Assign(out var chck1),
							new Label()
								.Column(1)
								.Text("Item 1")
								.VerticalTextAlignment(TextAlignment.Center)
								.FillBothDirections()
								.GestureRecognizers([
									new TapGestureRecognizer()
										.NumberOfTapsRequired(1)
										.OnTapped((s,e) => {
											chck1.IsChecked = !chck1.IsChecked;
										})
								])
						]),
					new BoxView().Divider(),
					new Grid()
						.ColumnDefinitions(e => e.Auto().Star())
						.Children([
							new CheckBox().Assign(out var chck2),
							new Label()
								.Column(1)
								.Text("Item 2")
								.VerticalTextAlignment(TextAlignment.Center)
								.FillBothDirections()
								.GestureRecognizers([
									new TapGestureRecognizer()
										.NumberOfTapsRequired(1)
										.OnTapped((s,e) => {
											chck2.IsChecked = !chck2.IsChecked;
										})
								])
						]),
					new BoxView().Divider(),
					new Grid()
						.ColumnDefinitions(e => e.Auto().Star())
						.Children([
							new CheckBox().Assign(out var chck3),
							new Label()
								.Column(1)
								.Text("Item 2")
								.VerticalTextAlignment(TextAlignment.Center)
								.FillBothDirections()
								.GestureRecognizers([
									new TapGestureRecognizer()
										.NumberOfTapsRequired(1)
										.OnTapped((s,e) => {
											chck3.IsChecked = !chck3.IsChecked;
										})
								])
						]),
				]));
		#endregion

		#region Collection View Example
		var collectionView = new CollectionView()
			.ItemsSource(e => e.Path(nameof(ListGroupViewModel.Items)).Source(BindingContext))
			.ItemTemplate(new DataTemplate(() => {
				var view = new ListGroupItemView();
				view.SetBinding(BindingContextProperty, ".");
				return view;
			}));
		var collectionViewListGroup = new Border()
			.ListGroup()
			.Content(collectionView);
		#endregion

		this
			.Title("List Groups")
			.Content(new ScrollView()
				.Content(new VerticalStackLayout()
					.Padding(16)
					.Children([
						_Border,
						new BoxView().Divider().Margin(16),
						_BorderComplex,
						new BoxView().Divider().Margin(16),
						horizontalListGroup,
						new BoxView().Divider().Margin(16),
						variantListGroup,
						new BoxView().Divider().Margin(16),
						badgesInListGroups,
						new BoxView().Divider().Margin(16),
						radioListGroups,
						new BoxView().Divider().Margin(16),
						checkboxListGroup,
						new BoxView().Divider().Margin(16),
						collectionViewListGroup
					])
				)
			);
	}
}

public class ListGroupItemView : VerticalStackLayout
{
    private readonly Label _Text = new Label()
		.Padding(8)
		.FillBothDirections()
		.VerticalTextAlignment(TextAlignment.Center)
		.FontFamily(e => e.Path(nameof(DynamicConstants.BoldFont)).Source(DynamicConstants.Instance));
	private readonly BoxView _Divider = new BoxView()
		.Divider();

	public ListGroupItemView()
	{
		this.Children([
			_Text,
			_Divider
		]);
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == BindingContextProperty.PropertyName && 
			BindingContext is ListGroupItem item)
		{
			_Text.Text = $"{item.Index} {item.Text}";
			if (item.Index == 3)
			{
				_Divider.IsVisible(false);
			}
		}
    }
}