using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using SampleApp.Controls;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class ShimmersDemoPage : ContentPage
{
    private ShimmersViewModel _ViewModel => (ShimmersViewModel)BindingContext;
    
    #region UI
    private readonly Grid _ContentLayout = new Grid()
        .RowDefinitions(e => e.Star().Auto())
        .RowSpacing(8)
        .Padding(8);

    private readonly RefreshView _Refresh = new RefreshView();
    private readonly CollectionView _ShimmersCollection = new CollectionView()
        .ItemsLayout(new LinearItemsLayout(ItemsLayoutOrientation.Vertical).ItemSpacing(8));
    private readonly Button _TriggerRefresh = new Button()
        .Primary()
        .Text(e => e.Translate("Refresh"));
    #endregion
    
    #region Constructor
    public ShimmersDemoPage(ShimmersViewModel shimmersViewModel)
    {
        BindingContext = shimmersViewModel;
        
        _ShimmersCollection
            .ItemTemplate(new DataTemplate(() =>
            {
                var shimmerCard = new ShimmerCard();
                shimmerCard.SetBinding(BindingContextProperty, ".");
                shimmerCard.SetBinding(ShimmerCard.ImageSourceProperty, nameof(ShimmerModel.ImageSource));
                shimmerCard.SetBinding(ShimmerCard.ShimmeringProperty, nameof(ShimmerModel.Shimmering));
                shimmerCard.SetBinding(ShimmerCard.TitleProperty, nameof(ShimmerModel.Title));
                shimmerCard.SetBinding(ShimmerCard.SubTitleProperty, nameof(ShimmerModel.SubTitle));
                shimmerCard.SetBinding(ShimmerCard.ActionTextProperty, nameof(ShimmerModel.ActionText));
                shimmerCard.Submitted += ShimmerSubmitted;
                return shimmerCard;
            }));

        _Refresh.Command(new Command(Refresh));
        _TriggerRefresh.OnClicked((s, e) => Refresh());

        _Refresh.Content(_ShimmersCollection);
        _ContentLayout.Children([
            _Refresh.Row(0).FillBothDirections(),
            _TriggerRefresh.Row(1).Center()
        ]);

        this
            .Title(e => e.Translate("Shimmers"))
            .Content(_ContentLayout);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Refresh();
    }
    #endregion

    #region Logic
    private async void Refresh()
    {
        _ShimmersCollection.ItemsSource = _ViewModel.Shimmers;
        await _ViewModel.FetchShimmers();
        _ShimmersCollection.ItemsSource = _ViewModel.Data;
        
        _Refresh.IsRefreshing = false;
    }

    private void ShimmerSubmitted(object? sender, EventArgs e)
    {
        if (sender is ShimmerCard { BindingContext: ShimmerModel model })
        {
            Toast.Make(model.Title).Show();
        }
    }
    #endregion
}

public partial class ShimmersViewModel : ObservableObject
{
    [ObservableProperty] 
    private ObservableCollection<ShimmerModel> _Data = [];

    [ObservableProperty] 
    private ObservableCollection<ShimmerModel> _Shimmers = [];

    public ShimmersViewModel()
    {
        Shimmers.Add(new ShimmerModel { Shimmering = true  });
        Shimmers.Add(new ShimmerModel { Shimmering = true  });
        Shimmers.Add(new ShimmerModel { Shimmering = true  });
    }
    
    public async Task FetchShimmers()
    {
        Data.Clear();
        
        await Task.Delay(5000); // ms, simulate work 
        
        Data.Add(new ShimmerModel
        {
            Title = "Card One",
            SubTitle = "This is some text for the card to show as a subtitle",
            ImageSource = "https://picsum.photos/200/120",
            ActionText = "Submit"
        });
        Data.Add(new ShimmerModel
        {
            Title = "Card Two",
            SubTitle = "This is some text for the card to show as a subtitle",
            ImageSource = "https://picsum.photos/200/120",
            ActionText = "Submit"
        });
        Data.Add(new ShimmerModel
        {
            Title = "Card Three",
            SubTitle = "This is some text for the card to show as a subtitle",
            ImageSource = "https://picsum.photos/200/120",
            ActionText = "Submit"
        });
    }
}