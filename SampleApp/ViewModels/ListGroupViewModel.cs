using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleApp.ViewModels;

public partial class ListGroupViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ListGroupItem> items = [];

    public ListGroupViewModel()
    {
        Items.Add(new ListGroupItem
        {
            Index = 1,
            Text = "Some item description"
        });
        Items.Add(new ListGroupItem
        {
            Index = 2,
            Text = "Some item description"
        });
        Items.Add(new ListGroupItem
        {
            Index = 3,
            Text = "Some item description"
        });
    }
}

public partial class ListGroupItem : ObservableObject 
{
    [ObservableProperty]
    private int index = 0;

    [ObservableProperty]
    private string text = string.Empty;
}
