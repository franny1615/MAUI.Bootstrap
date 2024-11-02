using System.Timers;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MAUIBootstrap.Controls;

public class SpinnerControl : SKCanvasView
{
    #region Properties
    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        nameof(IsLoading),
        typeof(bool),
        typeof(SpinnerControl),
        false);
    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(SpinnerControl),
        BootstrapColors.Primary);
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public static readonly BindableProperty DiameterProperty = BindableProperty.Create(
        nameof(Diameter),
        typeof(int),
        typeof(SpinnerControl),
        0);
    public int Diameter
    {
        get => (int)GetValue(DiameterProperty);
        set => SetValue(DiameterProperty, value);
    }
    
    public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(
        nameof(StrokeThickness),
        typeof(int),
        typeof(SpinnerControl),
        10);

    public int StrokeThickness
    {
        get => (int)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
    #endregion
    
    #region Private properties
    private readonly System.Timers.Timer _Timer = new()
    {
        AutoReset = true,
        Interval = 16
    };
    private float _StartAngle = 0f;
    #endregion
    
    #region Constructor
    public SpinnerControl()
    {
        PaintSurface += OnPaintSurface;
        _Timer.Elapsed += TimerOnElapsed;
        Diameter = 16; // default
    }
    #endregion
    
    #region Timer Elapsed
    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        _StartAngle += 5;
        if (_StartAngle >= 360)
            _StartAngle = 0;
        MainThread.BeginInvokeOnMainThread(InvalidateSurface);
    }
    #endregion
    
    #region Paint Surface
    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Transparent);  // Clear canvas with a white background

        var centerX = e.Info.Width * 0.5f;
        var centerY = e.Info.Height * 0.5f;
        var radius = Math.Min(centerX, centerY) - 4;  // Circle radius with padding

        // Define paint for the circular spinner
        using var paint = new SKPaint();
        paint.Style = SKPaintStyle.Stroke;
        paint.Color = Color.ToSKColor();
        paint.StrokeWidth = StrokeThickness;
        paint.IsAntialias = true;
        paint.StrokeCap = SKStrokeCap.Round;

        // Draw the animated arc (spinner)
        var rect = new SKRect(
            centerX - radius, 
            centerY - radius, 
            centerX + radius, 
            centerY + radius);
        
        canvas.DrawArc(
            rect, 
            _StartAngle, 
            270, 
            false, 
            paint);
    }
    #endregion
    
    #region OnPropertyChanged
    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == IsLoadingProperty.PropertyName)
        {
            if (IsLoading)
            {
                _StartAngle = 0f;
                _Timer.Start();
            }
            else
            {
                _Timer.Stop();
            }
        }
        else if (propertyName == DiameterProperty.PropertyName)
        {
            WidthRequest = Diameter;
            HeightRequest = Diameter;
        }
    }
    #endregion
}