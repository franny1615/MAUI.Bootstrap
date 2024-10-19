using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Extensions;

public static class BorderExtensions
{
    public static Border ListGroup(this Border border)
    {
        border
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Stroke(BootstrapColors.Secondary)
            .StrokeThickness(1);
        return border;
    }
}
