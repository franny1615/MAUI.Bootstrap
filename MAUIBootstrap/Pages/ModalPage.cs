using System.Runtime.CompilerServices;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Pages;

public class ModalPage : ContentPage
{
	#region Event
	public event EventHandler? Closed;
	#endregion

	#region Properties
	public static readonly BindableProperty HeaderProperty = BindableProperty.Create(
		nameof(Header),
		typeof(View),
		typeof(ModalPage),
		null 
	);
	public View Header 
	{
		get => (View)GetValue(HeaderProperty);
		set => SetValue(HeaderProperty, value);
	}

	public static readonly BindableProperty BodyProperty = BindableProperty.Create(
		nameof(Body),
		typeof(View),
		typeof(ModalPage),
		null
	);
	public View Body
	{
		get => (View)GetValue(BodyProperty);
		set => SetValue(BodyProperty, value);
	}

	public static readonly BindableProperty IsFullScreenProperty = BindableProperty.Create(
		nameof(IsFullScreen),
		typeof(bool),
		typeof(ModalPage),
		false
	);

	public bool IsFullScreen
	{
		get => (bool)GetValue(IsFullScreenProperty);
		set => SetValue(IsFullScreenProperty, value);
	}

	public static readonly BindableProperty IsCloseVisibleProperty = BindableProperty.Create(
		nameof(IsCloseVisible),
		typeof(bool),
		typeof(ModalPage),
		true
	);

	public bool IsCloseVisible
	{
		get => (bool)GetValue(IsCloseVisibleProperty);
		set => SetValue(IsCloseVisibleProperty, value);
	}
	#endregion

	#region UI
	private readonly Grid _MainContent = new Grid();
	private readonly Border _ContentBacking = new Border()
		.Stroke(BootstrapColors.Secondary)
		.StrokeThickness(1)
		.StrokeShape(new RoundRectangle().CornerRadius(5));
	private readonly Grid _ContentLayout = new Grid()
		.ColumnDefinitions(e => e.Star().Auto())
		.RowDefinitions(e => e.Auto().Absolute(1).Star());
	private readonly ContentView _Header = new ContentView();
	private readonly ContentView _Body = new ContentView();
	private readonly Button _Close = new Button()
		.MaterialIcon(MaterialIcon.Close, 32);
	#endregion

	#region Constructor
	public ModalPage()
	{
		this.BackgroundColor = BootstrapColors.Secondary.WithAlpha(0.15f);

		On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FullScreen);

		_Close.OnClicked((s,e) => {
			ManualClose();
		});

		_ContentLayout.Children([
			_Header.Column(0).Row(0).Padding(8,8,0,8),
			_Close.Column(1).Row(0).Center().Padding(0,8,8,8),
			new BoxView().Divider().Row(1).Column(0).ColumnSpan(2),
			_Body.Row(2).Column(0).ColumnSpan(2).Padding(8)
		]);

		_ContentBacking.Content(_ContentLayout);
		_ContentBacking.SetDynamicResource(BackgroundColorProperty, nameof(BootstrapColors.ModalColor));

		_Header.Content(e => e.Path(nameof(Header)).Source(this));
		_Body.Content(e => e.Path(nameof(Body)).Source(this));

		_MainContent
			.BackgroundColor(Colors.Transparent)
			.Children([
				_ContentBacking
					.Margin(16)
					.CenterHorizontal()
					.AlignTop()
			]);
		this.Content(_MainContent);

		SetMaxHeight();
	}
	public async void ManualClose()
	{
		await Navigation.PopModalAsync();
		Closed?.Invoke(this, EventArgs.Empty);
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		DeviceDisplay.Current.MainDisplayInfoChanged += DisplayChanged;
    }
    protected override void OnDisappearing()
    {
		DeviceDisplay.Current.MainDisplayInfoChanged -= DisplayChanged;
        base.OnDisappearing();
    }
    #endregion

	#region DisplayChanged
	private void DisplayChanged(object? sender, EventArgs e)
	{
		SetMaxHeight();
	}
	private void SetMaxHeight()
	{
		var height = DeviceDisplay.Current.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density;
		_ContentBacking.MaximumHeightRequest = height;
	}
	#endregion

    #region OnPropertyChanged
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == IsCloseVisibleProperty.PropertyName)
		{
			if (!IsCloseVisible)
			{
				_Header.ColumnSpan(2);
				_Close.IsVisible(false);
			}
			else
			{
				_Header.ColumnSpan(1);
				_Close.IsVisible(true);
			}
		}
		else if (propertyName == IsFullScreenProperty.PropertyName)
		{
			if (IsFullScreen)
			{
				_MainContent.IgnoreSafeArea(true);
				_ContentBacking.Margin(0);
				_ContentBacking.FillBothDirections();
				_ContentBacking.Stroke(Colors.Transparent);
			}
			else 
			{
				_MainContent.IgnoreSafeArea(false);
				_ContentBacking.Margin(16);
				_ContentBacking.CenterHorizontal().AlignTop();
				_ContentBacking.Stroke(BootstrapColors.Secondary);
			}
			SetMaxHeight();
		}
    }
    #endregion
}