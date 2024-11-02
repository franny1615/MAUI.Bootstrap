using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using MAUIBootstrap.Utilities;

namespace SampleApp.Pages;

public class ProgressControlsDemoPage : ContentPage 
{
    private readonly ProgressBar _Primary;
    private readonly ProgressBar _Success;
    private readonly ProgressBar _Warning;
    private readonly ProgressBar _Info;
    private readonly RoundRectSpinnerControl _Border;
    private readonly Debouncer _Debouncer = new(4);
    
    public ProgressControlsDemoPage()
    {
        this
            .Title("Progress Controls")
            .Content(new VerticalStackLayout()
                .Padding(16)
                .Spacing(16)
                .Children([
                    new HorizontalStackLayout()
                        .Center()
                        .Spacing(16)
                        .Children([
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Primary)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(6)
                                .Diameter(32)
                                .Color(BootstrapColors.Secondary)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(8)
                                .Diameter(32)
                                .Color(BootstrapColors.Success)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Danger)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Warning)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Info)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Light)
                                .Start(),
                            new SpinnerControl()
                                .StrokeThickness(4)
                                .Diameter(32)
                                .Color(BootstrapColors.Dark)
                                .Start(),
                        ]),
                    new ProgressBar()
                        .Assign(out _Primary)
                        .ProgressColor(BootstrapColors.Primary)
                        .BackgroundColor(Colors.Transparent),
                    new ProgressBar()
                        .Assign(out _Info)
                        .ProgressColor(BootstrapColors.Info)
                        .BackgroundColor(Colors.Transparent),
                    new ProgressBar()
                        .Assign(out _Success)
                        .ProgressColor(BootstrapColors.Success)
                        .BackgroundColor(Colors.Transparent),
                    new ProgressBar()
                        .Assign(out _Warning)
                        .ProgressColor(BootstrapColors.Warning)
                        .BackgroundColor(Colors.Transparent),
                    new RoundRectSpinnerControl()
                        .HeightRequest(50)
                        .MinimumWidthRequest(150)
                        .FillHorizontal()
                        .StaticBorderColor(BootstrapColors.Warning)
                        .StrokeThickness(8)
                        .CornerRadius(16)
                        .GradientColors([
                            BootstrapColors.Primary,
                            BootstrapColors.Success,
                            BootstrapColors.Info
                        ])
                        .Start()
                        .Center(),
                    new Grid()
                        .Children([
                            new RoundRectSpinnerControl()
                                .Assign(out _Border)
                                .MinimumHeightRequest(40)
                                .FillHorizontal()
                                .ZIndex(0)
                                .StaticBorderColor(BootstrapColors.Secondary)
                                .CornerRadius(16)
                                .StrokeThickness(DeviceInfo.Current.Platform == DevicePlatform.iOS ? 8 : 4)
                                .CornerRadius(12)
                                .GradientColors([
                                    BootstrapColors.Primary,
                                    BootstrapColors.Info
                                ]),
                            new EntryControl()
                                .IsBorderless(true)
                                .CenterVertical()
                                .Margin(8,0,8,0)
                                .ZIndex(1)
                                .Placeholder("Enter some text")
                                .OnTextChanged(async (s, e) =>
                                {
                                    if (!_Border.IsLoading)
                                        _Border.IsLoading = true;
                                    _Debouncer.Debounce(() =>
                                    {
                                        _Border.IsLoading = false;
                                    });
                                })
                        ])
                ]));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _Primary.ProgressTo(0.25, 750, Easing.Linear);
        _Info.ProgressTo(0.5, 750, Easing.Linear);
        _Success.ProgressTo(0.75, 750, Easing.Linear);
        _Warning.ProgressTo(1.0, 750, Easing.Linear);
    }
}