using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace SampleApp.Controls;

#region Model
public partial class ShimmerModel : ObservableObject
{
    [ObservableProperty] 
    private bool _Shimmering = false;
    
    [ObservableProperty]
    private string _Title = string.Empty;
    
    [ObservableProperty]
    private string _SubTitle = string.Empty;

    [ObservableProperty] 
    private ImageSource _ImageSource = "";
}
#endregion 

public class ShimmerCard : Border
{
    public event EventHandler? Submitted;
    
    #region Properties
    public static readonly BindableProperty ShimmeringProperty = BindableProperty.Create(
        nameof(Shimmering),
        typeof(bool),
        typeof(ShimmerCard),
        false);

    public bool Shimmering
    {
        get => (bool)GetValue(ShimmeringProperty);
        set => SetValue(ShimmeringProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(ShimmerCard),
        null);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty SubTitleProperty = BindableProperty.Create(
        nameof(SubTitle),
        typeof(string),
        typeof(ShimmerCard),
        null);

    public string SubTitle
    {
        get => (string)GetValue(SubTitleProperty);
        set => SetValue(SubTitleProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource),
        typeof(ImageSource),
        typeof(ShimmerCard),
        null);

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    #endregion

    #region UI
    private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout()
        .Spacing(8);
    private readonly Image _ImageSource = new Image()
        .Aspect(Aspect.Fill)
        .MinimumHeightRequest(120);
    private readonly Label _Title = new Label()
        .FontFamily(DynamicConstants.Instance.BoldFont)
        .FontSize(21)
        .MinimumWidthRequest(120)
        .MinimumHeightRequest(21)
        .AlignLeft()
        .Margin(8,0,8,0);
    private readonly Label _SubTitle = new Label()
        .FontSize(16)
        .MinimumHeightRequest(21)
        .MinimumWidthRequest(90)
        .AlignLeft()
        .Margin(8,0,8,0);
    private readonly Button _Action = new Button()
        .Primary()
        .Text(e => e.Translate("Submit"))
        .AlignLeft()
        .MinimumWidthRequest(90)
        .MinimumHeightRequest(21)
        .Margin(8,0,8,8);
    #endregion
    
    #region Constructor
    public ShimmerCard()
    {
        _ImageSource.Source(e => e.Path(nameof(ImageSource)).Source(this));
        _Title.Text(e => e.Path(nameof(Title)).Source(this));
        _SubTitle.Text(e => e.Path(nameof(SubTitle)).Source(this));
        _Action.OnClicked((s, e) =>
        {
            if (Shimmering)
                return;
            
            Submitted?.Invoke(this, EventArgs.Empty);
        });
        
        this
            .Stroke(BootstrapColors.Secondary)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Content(_ContentLayout
            .Children([
                _ImageSource,
                _Title,
                _SubTitle,
                _Action
            ]));
    }
    #endregion
    
    #region OnPropertyChanged

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == ShimmeringProperty.PropertyName)
        {
            TriggerShimmering();
        }
    }
    #endregion
    
    #region Shimmering Task

    private void TriggerShimmering()
    {
        if (!Shimmering)
        {
            _Title.ClearPlaceholder();
            _SubTitle.ClearPlaceholder();
            _Action.Primary();
            
            _Action.Text(e => e.Translate("Submit"));
            return;
        }

        Task.Run(async () =>
        {
            while (Shimmering)
            {
                _ImageSource.SecondaryPlaceholder();
                _Title.SecondaryPlaceholder();
                _SubTitle.SecondaryPlaceholder();
                _Action.PrimaryPlaceholder();
                _Action.Text("");
                
                await _ContentLayout.FadeTo(0.85f);
                await _ContentLayout.FadeTo(1);
            }
        });
    }
    #endregion
}

public static class ShimmerCardExtensions
{
    #region Shimmering
    public static T Shimmering<T>(
        this T self, 
        bool source) where T : ShimmerCard
    {
        self.SetValue(ShimmerCard.ShimmeringProperty, source);
        return self;
    }

    public static T Shimmering<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : ShimmerCard
    {
        var context = new PropertyContext<bool>(self, ShimmerCard.ShimmeringProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Shimmering<T>(
        this SettersContext<T> self,
        bool source)
        where T : ShimmerCard
    {
        self.XamlSetters.Add(new Setter { Property = ShimmerCard.ShimmeringProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Shimmering<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
            IPropertySettersBuilder<bool>> configure) where T : ShimmerCard
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, ShimmerCard.ShimmeringProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region Title
    public static T Title<T>(
        this T self, 
        string source) where T : ShimmerCard
    {
        self.SetValue(ShimmerCard.TitleProperty, source);
        return self;
    }

    public static T Title<T>(
        this T self, 
        Func<PropertyContext<string >, IPropertyBuilder<string >> configure) where T : ShimmerCard
    {
        var context = new PropertyContext<string >(self, ShimmerCard.TitleProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Title<T>(
        this SettersContext<T> self,
        string  source)
        where T : ShimmerCard
    {
        self.XamlSetters.Add(new Setter { Property = ShimmerCard.TitleProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Title<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<string >, 
            IPropertySettersBuilder<string >> configure) where T : ShimmerCard
    {
        var context = new PropertySettersContext<string >(self.XamlSetters, ShimmerCard.TitleProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region Subtitle
    public static T SubTitle<T>(
        this T self, 
        string  source) where T : ShimmerCard
    {
        self.SetValue(ShimmerCard.SubTitleProperty, source);
        return self;
    }

    public static T SubTitle<T>(
        this T self, 
        Func<PropertyContext<string >, IPropertyBuilder<bool>> configure) where T : ShimmerCard
    {
        var context = new PropertyContext<string >(self, ShimmerCard.SubTitleProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> SubTitle<T>(
        this SettersContext<T> self,
        string  source)
        where T : ShimmerCard
    {
        self.XamlSetters.Add(new Setter { Property = ShimmerCard.SubTitleProperty, Value = source });
        return self;
    }

    public static SettersContext<T> SubTitle<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<string >, 
            IPropertySettersBuilder<string >> configure) where T : ShimmerCard
    {
        var context = new PropertySettersContext<string >(self.XamlSetters, ShimmerCard.SubTitleProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region ImageSource
    public static T ImageSource<T>(
        this T self, 
        ImageSource source) where T : ShimmerCard
    {
        self.SetValue(ShimmerCard.ImageSourceProperty, source);
        return self;
    }

    public static T ImageSource<T>(
        this T self, 
        Func<PropertyContext<ImageSource>, IPropertyBuilder<ImageSource>> configure) where T : ShimmerCard
    {
        var context = new PropertyContext<ImageSource>(self, ShimmerCard.ImageSourceProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> ImageSource<T>(
        this SettersContext<T> self,
        ImageSource source)
        where T : ShimmerCard
    {
        self.XamlSetters.Add(new Setter { Property = ShimmerCard.ImageSourceProperty, Value = source });
        return self;
    }

    public static SettersContext<T> ImageSource<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<ImageSource>, 
            IPropertySettersBuilder<ImageSource>> configure) where T : ShimmerCard
    {
        var context = new PropertySettersContext<ImageSource>(self.XamlSetters, ShimmerCard.ImageSourceProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}