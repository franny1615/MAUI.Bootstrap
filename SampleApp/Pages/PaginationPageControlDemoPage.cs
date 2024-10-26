using CommunityToolkit.Maui.Alerts;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class PaginationPageControlDemoPage : ContentPage 
{
    public PaginationPageControlDemoPage()
    {
        this
            .Title("Pagination Control")
            .Content(new VerticalStackLayout()
                .Spacing(16)
                .Padding(16)
                .Children([
                    new PaginationControl()
                        .CurrentPage(1)
                        .TotalPages(10)
                        .OnPageChanged(PageChanged)
                ]));
    }

    private void PageChanged(object? sender, PaginationEventArgs e)
    {
        Toast.Make($"{e.RequestedPage} was requested").Show();
    }
}