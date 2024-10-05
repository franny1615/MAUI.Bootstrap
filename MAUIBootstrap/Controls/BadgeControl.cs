using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Controls;

public class BadgeControl : Border 
{	
	#region Bindable Properties
	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		nameof(Text),
		typeof(string),
		typeof(BadgeControl),
		string.Empty
	);
	public string Text 
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty TextSizeProperty = BindableProperty.Create(
		nameof(TextSize),
		typeof(double),
		typeof(BadgeControl),
		16.0
	);
	public double TextSize
	{
		get => (double)GetValue(TextSizeProperty);
		set => SetValue(TextSizeProperty, value);
	}

	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
		nameof(TextColor),
		typeof(Color),
		typeof(BadgeControl),
		Colors.White
	);
	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
	#endregion

	#region Constructor
	public BadgeControl()
	{
		this.Content(
			new Label()
				.Text(e => e.Path(nameof(Text)).Source(this))
				.TextColor(e => e.Path(nameof(TextColor)).Source(this))
				.FontSize(e => e.Path(nameof(TextSize)).Source(this))
				.FontFamily(e => e
					.Path(nameof(DynamicConstants.BoldFont))
					.Source(DynamicConstants.Instance))
		)
		.Padding(8, 2, 8, 2)
		.Stroke(Colors.Transparent)
		.StrokeShape(new RoundRectangle().CornerRadius(5))
		.BackgroundColor(Colors.DarkGray);
	}
	#endregion 
}