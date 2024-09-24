using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Markup;
using MAUIBootstrap.Utilities;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MAUIBootstrap.Controls;

public class AccordionControl : Border 
{
	#region Bindable Properties
	public static readonly BindableProperty HeaderProperty = BindableProperty.Create(
		nameof(Header),
		typeof(View),
		typeof(AccordionControl)
	);
	public View Header 
	{
		get => (View)GetValue(HeaderProperty);
		set => SetValue(HeaderProperty, value);
	}

	public static readonly BindableProperty AccordionContentProperty = BindableProperty.Create(
		nameof(AccordionContent),
		typeof(View),
		typeof(AccordionControl)
	);
	public View AccordionContent 
	{
		get => (View)GetValue(AccordionContentProperty);
		set => SetValue(AccordionContentProperty, value);
	}

	public static readonly BindableProperty IsCollapsedProperty = BindableProperty.Create(
		nameof(IsCollapsed),
		typeof(bool),
		typeof(AccordionControl),
		true
	);
	public bool IsCollapsed
	{
		get => (bool)GetValue(IsCollapsedProperty);
		set => SetValue(IsCollapsedProperty, value);
	}

	public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(
		nameof(IconSize),
		typeof(int),
		typeof(AccordionControl),
		48
	);
	public int IconSize
	{
		get => (int)GetValue(IconSizeProperty);
		set => SetValue(IconSizeProperty, value);
	}
	#endregion

	#region UI Definitions
	private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout().Spacing(0);
	private readonly Grid _Header = new();
	private readonly Image _Chevron = new Image().Margin(8);
	private readonly BoxView _Divider = new BoxView().MakeDivider(Colors.DarkGray);
	private readonly TapGestureRecognizer _CollapseTap = new TapGestureRecognizer().TapsRequired(1);
	#endregion

	#region Constructor
	public AccordionControl()
	{
		Margin = 0;
		Content = _ContentLayout;
		_Header.ColumnDefinitions = Columns.Define(Star, IconSize);
		_Header.GestureRecognizers.Add(_CollapseTap);
		_CollapseTap.Tapped += OnCollapseTap;
	}
	#endregion

	#region Methods
	private async void OnCollapseTap(object? sender, EventArgs e)
	{
		await _Header.BackgroundColorTo(Colors.Black.WithAlpha(0.25f), 10);
		_ = _Header.BackgroundColorTo(Colors.Transparent, 10);
		IsCollapsed = !IsCollapsed;
	}

	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == HeaderProperty.PropertyName ||
			propertyName == AccordionContentProperty.PropertyName)
		{
			_Header.Clear();
			_Header.Add(Header.Column(0));
			_Header.Add(_Chevron.Center().Column(1));

			_ContentLayout.Clear();
			_ContentLayout.Add(_Header);
			_ContentLayout.Add(_Divider);
			_ContentLayout.Add(AccordionContent);
			ApplyCollapseLogic();
		}
		else if (propertyName == IsCollapsedProperty.PropertyName)
		{
			ApplyCollapseLogic();
		}
		else if (propertyName == StrokeProperty.PropertyName && Stroke is SolidColorBrush solidBrush)
		{
			_Divider.MakeDivider(solidBrush.Color);
			_Chevron.ApplyMaterialIcon(
				IsCollapsed ? MaterialIcon.Keyboard_arrow_down : MaterialIcon.Keyboard_arrow_up, 
				solidBrush.Color, 
				IconSize); 
		}
		else if (propertyName == IconSizeProperty.PropertyName)
		{
			var stroke = Colors.DarkGray;
			if (Stroke is SolidColorBrush solidColorBrush)
				stroke = solidColorBrush.Color;
			_Header.ColumnDefinitions = Columns.Define(Star, IconSize);
			_Chevron.ApplyMaterialIcon(
				IsCollapsed ? MaterialIcon.Keyboard_arrow_down : MaterialIcon.Keyboard_arrow_up, 
				stroke, 
				IconSize); 
		}
    }

	private void ApplyCollapseLogic()
	{
		Color stroke = Colors.DarkGray;
		if (Stroke is SolidColorBrush solidBrush)
			stroke = solidBrush.Color;

		if (IsCollapsed)
		{
			_Chevron.ApplyMaterialIcon(MaterialIcon.Keyboard_arrow_down, stroke, IconSize);
			_Divider.IsVisible = false;
			if (AccordionContent != null)
			{
				AccordionContent.HeightRequest = 0;
			}
		}
		else 
		{
			_Chevron.ApplyMaterialIcon(MaterialIcon.Keyboard_arrow_up, stroke, IconSize);
			_Divider.IsVisible = true;
			if (AccordionContent != null)
			{
				AccordionContent.HeightRequest = -1;
			}
		}
	}
	#endregion
}