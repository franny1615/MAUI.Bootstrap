using System.Runtime.CompilerServices;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;
using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public class AlertControl : Border
{
	public event EventHandler? CloseClicked;

	#region Bindable Property
	public static BindableProperty TimeoutProperty = BindableProperty.Create(
		nameof(Timeout),
		typeof(TimeSpan),
		typeof(AlertControl),
		TimeSpan.FromMinutes(0)
	);
	public TimeSpan Timeout
	{
		get => (TimeSpan)GetValue(TimeoutProperty);
		set => SetValue(TimeoutProperty, value);
	}

	public static BindableProperty DismissableProperty = BindableProperty.Create(
		nameof(Dismissable),
		typeof(bool),
		typeof(AlertControl),
		true
	);
	public bool Dismissable
	{
		get => (bool)GetValue(DismissableProperty);
		set => SetValue(DismissableProperty, value);
	}

	public static BindableProperty AlertContentProperty = BindableProperty.Create(
		nameof(AlertContent),
		typeof(View),
		typeof(AlertControl),
		null
	);
	public View AlertContent
	{
		get => (View)GetValue(AlertContentProperty);
		set => SetValue(AlertContentProperty, value);
	}

	public static BindableProperty DismissIconProperty = BindableProperty.Create(
		nameof(DismissIcon),
		typeof(ImageSource),
		typeof(AlertControl),
		null
	);
	public ImageSource DismissIcon
	{
		get => (ImageSource)GetValue(DismissIconProperty);
		set => SetValue(DismissIconProperty, value);
	}
	#endregion

	#region UI Definitions
	private readonly Grid _ContentLayout = new Grid()
		.ColumnDefinitions(defs => defs.Star().Absolute(32))
		.ColumnSpacing(8);
	private readonly Image _CloseIcon = new();
	#endregion

	#region Constructor
	public AlertControl()
	{
		this
			.Content(_ContentLayout)
			.Stroke(Colors.Transparent)
			.StrokeShape(new RoundRectangle().CornerRadius(5));
		_CloseIcon
			.Source(e => e.Path(nameof(DismissIcon)).Source(this))
			.GestureRecognizers(new TapGestureRecognizer()
			.Command(new Command(async () => 
				{
					await _CloseIcon.ScaleTo(0.95, 70);
					await _CloseIcon.ScaleTo(1.0, 70);

					CloseClicked?.Invoke(this, EventArgs.Empty);
				})
			));
	}
    #endregion

    #region Methods
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == DismissableProperty.PropertyName)
		{
			LayoutItems();
		}
		else if (propertyName == AlertContentProperty.PropertyName)
		{
			LayoutItems();
		}
		else if (propertyName == TimeoutProperty.PropertyName)
		{
			Task.Run(async () => 
			{
				await Task.Delay(Timeout);
				MainThread.BeginInvokeOnMainThread(() => 
				{
					CloseClicked?.Invoke(this, EventArgs.Empty);
				});
			});
		}
    }

	private void LayoutItems()
	{
		_ContentLayout.Clear();
		if (AlertContent != null)
		{
			_ContentLayout.Add(AlertContent.Column(0));
		}
		_ContentLayout.Add(_CloseIcon.Center().Column(1));

		_CloseIcon.IsVisible = Dismissable;
		if (AlertContent != null)
			AlertContent.ColumnSpan(Dismissable ? 1 : 2);
	}
	#endregion
}