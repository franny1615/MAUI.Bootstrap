using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Markup;
using MAUIBootstrap.Utilities;
using Microsoft.Maui.Controls.Shapes;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MAUIBootstrap.Controls;

public enum AlertType 
{
	Primary,
	Secondary,
	Success,
	Danger,
	Warning,
	Info,
	Light,
	Dark
}

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

	public static BindableProperty AlertTypeProperty = BindableProperty.Create(
		nameof(AlertType),
		typeof(AlertType),
		typeof(AlertControl),
		AlertType.Primary
	);
	public AlertType AlertType
	{
		get => (AlertType)GetValue(AlertTypeProperty);
		set => SetValue(AlertTypeProperty, value);
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
	#endregion

	#region UI Definitions
	private readonly Grid _ContentLayout = new()
	{
		ColumnDefinitions = Columns.Define(Star, 32),
		ColumnSpacing = 8
	};
	private readonly Image _CloseIcon = new();
	#endregion

	#region Constructor
	public AlertControl()
	{
		Content = _ContentLayout;	

		_CloseIcon.TapGesture(async () => 
		{
			await _CloseIcon.ScaleTo(0.95, 70);
			await _CloseIcon.ScaleTo(1.0, 70);

			CloseClicked?.Invoke(this, EventArgs.Empty);
		});

		ApplyAlertTypeStyle();
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
				CloseClicked?.Invoke(this, EventArgs.Empty);
			});
		}
		else if (propertyName == AlertTypeProperty.PropertyName)
		{
			ApplyAlertTypeStyle();
		}
    }

	private void LayoutItems()
	{
		_ContentLayout.Clear();
		_ContentLayout.Add(AlertContent.Column(0));
		_ContentLayout.Add(_CloseIcon.Column(1));

		_CloseIcon.IsVisible = Dismissable;
		if (AlertContent != null)
			AlertContent.ColumnSpan(Dismissable ? 1 : 2);
	}

	private void ApplyAlertTypeStyle()
	{
		Color? color = null;
		Color? bgColor = null;
		StrokeThickness = 1;
		StrokeShape = new RoundRectangle { CornerRadius = 8 };
        switch (AlertType)
        {
            case AlertType.Primary:
				color = Colors.White;
				bgColor = Color.FromArgb("#0d6efd");
                break;
            case AlertType.Secondary:
				color = Colors.White;
				bgColor = Color.FromArgb("#6c757d");
                break;
            case AlertType.Success:
				color = Colors.White;
				bgColor = Color.FromArgb("#198754");
                break;
            case AlertType.Danger:
				color = Colors.White;
				bgColor = Color.FromArgb("#dc3545");
                break;
            case AlertType.Warning:
				color = Colors.Black;
				bgColor = Color.FromArgb("#ffc107");
                break;
            case AlertType.Info:
				color = Colors.Blue;
				bgColor = Color.FromArgb("#0dcaf0");
                break;
            case AlertType.Light:
				color = Colors.Black;
				bgColor = Colors.White;
                break;
            case AlertType.Dark:
				color = Colors.White;
				bgColor = Colors.Black;
                break;
        }
		Stroke = color;
		_CloseIcon.ApplyMaterialIcon(MaterialIcon.Close, color ?? Colors.White, 32);
		BackgroundColor = bgColor;
    }
    #endregion
}