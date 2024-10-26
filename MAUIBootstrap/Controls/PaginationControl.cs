using CommunityToolkit.Maui.Extensions;
using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Controls;

public class PaginationEventArgs : EventArgs
{
    public int RequestedPage { get; set; } = 1;
}

public class PaginationControl : Border 
{
    public event EventHandler<PaginationEventArgs>? PaginationChanged;

    #region Properties
    public static readonly BindableProperty CurrentPageProperty = BindableProperty.Create(
        nameof(CurrentPage),
        typeof(int),
        typeof(PaginationControl),
        1);

    public int CurrentPage
    {
        get => (int)GetValue(CurrentPageProperty);
        set => SetValue(CurrentPageProperty, value);
    }

    public static readonly BindableProperty TotalPagesProperty = BindableProperty.Create(
        nameof(TotalPages),
        typeof(int),
        typeof(PaginationControl),
        1);

    public int TotalPages
    {
        get => (int)GetValue(TotalPagesProperty);
        set => SetValue(TotalPagesProperty, value);
    }
    #endregion

    #region UI
    private readonly HorizontalStackLayout _ContentLayout = [];
    private readonly Label _PreviousButton = new Label()
        .Padding(8,4,8,4)
        .TextColor(BootstrapColors.Secondary)
        .HorizontalTextAlignment(TextAlignment.Center)
        .VerticalTextAlignment(TextAlignment.Center)
        .FontFamily(nameof(MaterialIcon))
        .Text(MaterialIcon.Arrow_back_ios)
        .FontSize(18);
    private readonly Label _NextButton = new Label()
        .Padding(8,4,8,4)
        .TextColor(BootstrapColors.Secondary)
        .HorizontalTextAlignment(TextAlignment.Center)
        .VerticalTextAlignment(TextAlignment.Center)
        .FontFamily(nameof(MaterialIcon))
        .Text(MaterialIcon.Arrow_forward_ios)
        .FontSize(18);
    private readonly Span _CurrentPageSpan = new Span();
    private readonly Span _TotalPageSpan = new Span();
    private readonly Label _IndicatorMarker = new Label()
        .Padding(0,4,0,4)
        .HorizontalTextAlignment(TextAlignment.Center)
        .VerticalTextAlignment(TextAlignment.Center)
        .FontSize(18)
        .FontFamily(DynamicConstants.Instance.BoldFont);
    #endregion
    
    #region Constructor
    public PaginationControl()
    {
        this
            .CenterHorizontal()
            .Stroke(BootstrapColors.Secondary)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .StrokeThickness(1)
            .Padding(0)
            .Margin(0)
            .Content(_ContentLayout);
        _PreviousButton.GestureRecognizers(new TapGestureRecognizer()
            .NumberOfTapsRequired(1)
            .OnTapped(Previous));
        _NextButton.GestureRecognizers(new TapGestureRecognizer()
            .NumberOfTapsRequired(1)
            .OnTapped(Next));
        _ContentLayout.Add(_PreviousButton);
        _ContentLayout.Add(_IndicatorMarker);
        _ContentLayout.Add(_NextButton);

        _IndicatorMarker.FormattedText(new FormattedString().Spans([
            _CurrentPageSpan,
            new Span().FontFamily(DynamicConstants.Instance.BoldFont).Text(" / "),
            _TotalPageSpan
        ]));
        
        _CurrentPageSpan.Text(e => e.Path(nameof(CurrentPage)).Source(this));
        _TotalPageSpan.Text(e => e.Path(nameof(TotalPages)).Source(this));
    }
    #endregion
    
    #region Previous

    private async void Previous(object? sender, EventArgs e)
    {
        _ = _PreviousButton.TextColorTo(Colors.White, 35);
        await _PreviousButton.BackgroundColorTo(BootstrapColors.Primary, 35);
        _ = _PreviousButton.TextColorTo(BootstrapColors.Secondary);
        await _PreviousButton.BackgroundColorTo(Colors.Transparent, 35);
                
        if (CurrentPage - 1 <= 0)
            CurrentPage = 1;
        else
            CurrentPage -= 1;
        PaginationChanged?.Invoke(this, new PaginationEventArgs
        {
            RequestedPage = CurrentPage
        });
    }
    #endregion
    
    #region Next

    private async void Next(object? sender, EventArgs e)
    {
        _ = _NextButton.TextColorTo(Colors.White, 35);
        await _NextButton.BackgroundColorTo(BootstrapColors.Primary, 35);
        _ = _NextButton.TextColorTo(BootstrapColors.Secondary);
        await _NextButton.BackgroundColorTo(Colors.Transparent, 35);
                
        if (CurrentPage + 1 > TotalPages)
            CurrentPage = TotalPages;
        else
            CurrentPage += 1;
        PaginationChanged?.Invoke(this, new PaginationEventArgs
        {
            RequestedPage = CurrentPage
        });
    }
    #endregion
}
