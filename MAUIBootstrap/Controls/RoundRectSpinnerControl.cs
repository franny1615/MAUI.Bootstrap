using System.Timers;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MAUIBootstrap.Controls;

public class RoundRectSpinnerControl : SKCanvasView
{
    #region Properties
    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        nameof(IsLoading),
        typeof(bool),
        typeof(RoundRectSpinnerControl),
        false);
    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }
    
    public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(
        nameof(StrokeThickness),
        typeof(int),
        typeof(RoundRectSpinnerControl),
        10);
    public int StrokeThickness
    {
        get => (int)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
    
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(CornerRadius),
        typeof(int),
        typeof(RoundRectSpinnerControl),
        5);
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    
    public static readonly BindableProperty GradientColorsProperty = BindableProperty.Create(
        nameof(GradientColors),
        typeof(List<Color>),
        typeof(RoundRectSpinnerControl),
        new List<Color> { BootstrapColors.Primary });

    public List<Color> GradientColors
    {
        get => (List<Color>)GetValue(GradientColorsProperty);
        set => SetValue(GradientColorsProperty, value);
    }

    public static readonly BindableProperty StaticBorderColorProperty = BindableProperty.Create(
        nameof(StaticBorderColor),
        typeof(Color),
        typeof(RoundRectSpinnerControl),
        BootstrapColors.Secondary);

    public Color StaticBorderColor
    {
        get => (Color)GetValue(StaticBorderColorProperty);
        set => SetValue(StaticBorderColorProperty, value);
    }
    
    public static readonly BindableProperty BlurProperty = BindableProperty.Create(
        nameof(Blur),
        typeof(int),
        typeof(RoundRectSpinnerControl),
        0);

    public int Blur
    {
        get => (int)GetValue(BlurProperty);
        set => SetValue(BlurProperty, value);
    }
    
    public static readonly BindableProperty InsetProperty = BindableProperty.Create(
        nameof(Inset),
        typeof(int),
        typeof(RoundRectSpinnerControl),
        8);

    public int Inset
    {
        get => (int)GetValue(InsetProperty);
        set => SetValue(InsetProperty, value);
    }
    #endregion
    
    #region Private properties
    private readonly System.Timers.Timer _Timer = new()
    {
        AutoReset = true,
        Interval = 32
    };
    private float _StartAngle = 0f;
    private int _FirstLoopDone = 0;
    #endregion
    
    #region Constructor
    public RoundRectSpinnerControl()
    {
        PaintSurface += OnPaintSurface;
        _Timer.Elapsed += TimerOnElapsed;
    }
    #endregion
    
    #region Timer Elapsed
    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        _StartAngle -= 5;
        if (_StartAngle == 0)
        {
            _StartAngle = 360;
            _FirstLoopDone = 1;
        }
        MainThread.BeginInvokeOnMainThread(InvalidateSurface);
    }
    #endregion
    
    #region Paint Surface
    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Transparent);  // Clear canvas

        #region DETERMINE INITIAL SIZE WITH PADDING 8
        var width = e.Info.Width - Inset;
        var height = e.Info.Height - Inset;
        var radius = CornerRadius;  // Corner radius for the rounded rectangle
        #endregion

        #region ADD INITIAL PATH
        // Define the rounded rectangle path
        var rect = new SKRect(Inset, Inset, width, height);
        var path = new SKPath();
        path.AddRoundRect(rect, radius, radius);
        #endregion
        
        if (_FirstLoopDone == 0)
        {
            #region PAINT STATIC BORDER
            // Define the paint for the rounded rectangle spinner segment
            using var paint = new SKPaint();
            paint.Style = SKPaintStyle.Stroke;
            paint.Color = StaticBorderColor.ToSKColor();
            paint.StrokeWidth = StrokeThickness;
            paint.IsAntialias = true;
            paint.StrokeCap = SKStrokeCap.Round; // Smooth, rounded segment ends
            if (Blur > 0)
            {
                paint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, Blur);
            }
            // Draw the rotating arc segment along the rounded rectangle path
            canvas.DrawPath(path, paint);
            #endregion
        }

        if (!IsLoading)
            return;

        #region MAP GRADIENTS   
        // map the maui colors to SKColor
        var skColors = new SKColor[GradientColors.Count];
        for (var i = 0; i < GradientColors.Count; i++)
        {
            skColors[i] = GradientColors[i].ToSKColor();
        }
        #endregion
        
        #region GRADIENT FILL LOOP
        // Measure the path length using SKPathMeasure
        using var pathMeasure = new SKPathMeasure(path, false);
        var pathLength = pathMeasure.Length;
        
        // Calculate the rotating gradient's start and end points
        var rectCenter = new SKPoint(rect.MidX, rect.MidY);
        var gradientRadius = Math.Min(width, height) * 0.5f;

        // Convert rotation angle to radians
        var radians = MathF.PI * _StartAngle / 180f;
        var gradientX = rectCenter.X + gradientRadius * MathF.Cos(radians);
        var gradientY = rectCenter.Y + gradientRadius * MathF.Sin(radians);

        var gradientStart = new SKPoint(gradientX, gradientY);
        var gradientEnd = new SKPoint(rectCenter.X - (gradientX - rectCenter.X), rectCenter.Y - (gradientY - rectCenter.Y));

        // Define paint for the gradient along the entire path
        using var segmentPaint = new SKPaint();
        segmentPaint.Style = SKPaintStyle.Stroke;
        segmentPaint.StrokeWidth = StrokeThickness;
        segmentPaint.IsAntialias = true;
        segmentPaint.StrokeCap = SKStrokeCap.Round;
        segmentPaint.Shader = SKShader.CreateLinearGradient(
            gradientStart, 
            gradientEnd, 
            skColors, 
            null, 
            SKShaderTileMode.Clamp);
        if (Blur > 0)
        {
            segmentPaint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, Blur);
        }

        if (_FirstLoopDone == 0)
        {
            // Define a PathEffect to control the rotating segment length along the path
            segmentPaint.PathEffect = SKPathEffect.CreateDash(
                [pathLength * 1, pathLength], 
                _StartAngle * pathLength / 360);
        }
        else if (_FirstLoopDone == 1)
        {
            segmentPaint.PathEffect = null;
        }

        // Draw the gradient along the entire rounded rectangle path
        canvas.DrawPath(path, segmentPaint);
        #endregion
    }
    #endregion
    
    #region OnPropertyChanged
    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == IsLoadingProperty.PropertyName)
        {
            _StartAngle = 360f;
            _FirstLoopDone = 0;
            if (IsLoading)
            {
                _Timer.Start();
            }
            else
            {
                _Timer.Stop();
                InvalidateSurface();
            }
        }
    }
    #endregion
}