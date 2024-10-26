using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public partial class TabModel : ObservableObject
{
    public string UIID = Guid.NewGuid().ToString();

    [ObservableProperty]
    private string materialIcon = string.Empty;

    [ObservableProperty]
    private string translateKey = string.Empty;

    [ObservableProperty]
    private bool isActive = false;
}

public class TabEventArgs : EventArgs
{
    public TabModel? SelectedTab { get; set; } = null;
}

public enum TabOrientation
{
    Horizontal,
    Vertical 
}

public class TabControl : Grid 
{
    #region Events
    public event EventHandler<TabEventArgs>? TabSelected;
    #endregion

    #region Properties
    public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
        nameof(Orientation),
        typeof(TabOrientation),
        typeof(TabControl),
        TabOrientation.Horizontal
    );
    public TabOrientation Orientation
    {
        get => (TabOrientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public static readonly BindableProperty TabsProperty = BindableProperty.Create(
        nameof(Tabs),
        typeof(List<TabModel>),
        typeof(TabControl),
        null);
    public List<TabModel> Tabs
    {
        get => (List<TabModel>)GetValue(TabsProperty);
        set => SetValue(TabsProperty, value);
    }
    #endregion

    #region OnPropertyChanged
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == TabsProperty.PropertyName)
        {
            Clear();
            if (Tabs != null && Tabs.Count > 0)
            {
                switch (Orientation)
                {
                    case TabOrientation.Horizontal:
                        var columnDefinitions = new ColumnDefinitionCollection();
                        for (int i = 0; i < Tabs.Count; i++)
                        {
                            columnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                        }
                        ColumnDefinitions = columnDefinitions;
                        break;
                    case TabOrientation.Vertical:
                        var rowDefinitions = new RowDefinitionCollection();
                        for (int i = 0; i < Tabs.Count; i++)
                        {
                            rowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                        }
                        RowDefinitions = rowDefinitions;
                        RowSpacing = 8;
                        break;
                }

                for (int i = 0; i < Tabs.Count; i++)
                {
                    var tab = Tabs[i];
                    var tabLabel = new TabLabel(Orientation);
                    tabLabel.BindingContext(tab);
                    tabLabel.Tapped += (s, e) =>
                    {
                        if (s is TabLabel tab &&
                            tab.BindingContext is TabModel model)
                        {
                            if (!model.IsActive)
                            {
                                model.IsActive = true;
                                Tabs.ForEach((t) =>
                                {
                                    if (t.UIID != model.UIID)
                                    {
                                        t.IsActive = false;
                                    }
                                });
                            }
                            TabSelected?.Invoke(this, new TabEventArgs
                            {
                                SelectedTab = model
                            });
                        }
                    };

                    switch (Orientation)
                    {
                        case TabOrientation.Horizontal:
                            Add(tabLabel.Column(i));
                            break;
                        case TabOrientation.Vertical:
                            Add(tabLabel.Row(i));
                            break;
                    }
                }
            }
        }
    }
    #endregion
}

public class TabLabel : Label
{
    public event EventHandler? Tapped;

    #region Properties
    public static readonly BindableProperty MaterialIconProperty = BindableProperty.Create(
        nameof(MaterialIcon),
        typeof(string),
        typeof(TabLabel),
        null);
    public string MaterialIcon
    {
        get => (string)GetValue(MaterialIconProperty);
        set => SetValue(MaterialIconProperty, value);
    }

    public static readonly BindableProperty TranslateKeyProperty = BindableProperty.Create(
        nameof(TranslateKey),
        typeof(string),
        typeof(TabLabel),
        null);
    public string TranslateKey
    {
        get => (string)GetValue(TranslateKeyProperty);
        set => SetValue(TranslateKeyProperty, value);
    }

    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
        nameof(IsActive),
        typeof(bool),
        typeof(TabLabel),
        false);
    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }
    #endregion

    #region UI
    private readonly Span _IconSpan = new Span()
        .FontFamily(nameof(MaterialIcon))
        .TextColor(BootstrapColors.Secondary);
    private readonly Span _TitleSpan = new Span()
        .TextColor(BootstrapColors.Secondary);
    #endregion

    #region Instance
    private int _DefaultIconSize = 18;
    private int _DefaultTitleSize = 16;
    private int _ExpandedIconSize = 21;
    private int _ExpandedTitleSize = 18;
    #endregion

    #region Constructor
    public TabLabel(TabOrientation orientation)
    {
        if (orientation == TabOrientation.Vertical)
        {
            _DefaultIconSize = 18;
            _DefaultTitleSize = 21;
            _ExpandedIconSize = 18;
            _ExpandedTitleSize = 21;
        }

        _IconSpan.FontSize(_DefaultIconSize);
        _TitleSpan.FontSize(_DefaultTitleSize);

        this
            .Padding(4)
            .VerticalTextAlignment(TextAlignment.Center)
            .HorizontalTextAlignment(orientation == TabOrientation.Horizontal ? TextAlignment.Center : TextAlignment.Start)  
            .FormattedText(
                new FormattedString().Spans([
                    _IconSpan,
                    new Span().Text(orientation == TabOrientation.Horizontal ? "\n" : "  "),
                    _TitleSpan
                ])
            )
            .GestureRecognizers([
                new TapGestureRecognizer()
                    .NumberOfTapsRequired(1)
                    .OnTapped((s,e) => {
                        Tapped?.Invoke(this, EventArgs.Empty);
                    })
            ]);
    }
    #endregion

    #region OnPropertyChanged
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == BindingContextProperty.PropertyName &&
            BindingContext is TabModel tab)
        {
            this.SetBinding(IsActiveProperty, nameof(TabModel.IsActive));
            this.SetBinding(TranslateKeyProperty, nameof(TabModel.TranslateKey));
            this.SetBinding(MaterialIconProperty, nameof(TabModel.MaterialIcon));
        }
        else if (propertyName == TranslateKeyProperty.PropertyName)
        {
            _TitleSpan.Text(e => e.Translate(TranslateKey));
        }
        else if (propertyName == MaterialIconProperty.PropertyName)
        {
            _IconSpan.Text(MaterialIcon);
        }
        else if (propertyName == IsActiveProperty.PropertyName)
        {
            if (IsActive)
            {
                _IconSpan
                    .FontSize(_ExpandedIconSize)
                    .TextColor(BootstrapColors.Primary);
                _TitleSpan
                    .FontSize(_ExpandedTitleSize)
                    .TextColor(BootstrapColors.Primary)
                    .FontFamily(DynamicConstants.Instance.BoldFont);
            }
            else
            {
                _IconSpan
                    .FontSize(_DefaultIconSize)
                    .TextColor(BootstrapColors.Secondary);
                _TitleSpan
                    .FontSize(_DefaultTitleSize)
                    .FontFamily(DynamicConstants.Instance.RegularFont)
                    .TextColor(BootstrapColors.Secondary);
            }
        }
    }
    #endregion
}