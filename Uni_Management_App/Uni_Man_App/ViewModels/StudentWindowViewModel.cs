using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Uni_Man_App.ViewModels;

public partial class StudentWindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isPaneOpen = true;

    [ObservableProperty] private ViewModelBase _currentPage = new HomeViewModel();
    
    
    [ObservableProperty] private ListItemTemplate? _selectedListItem;

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var instance = Activator.CreateInstance(value.ModelType);
        if (instance is null) return;
        CurrentPage = (ViewModelBase)instance;
    }

    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomeViewModel)),
        new ListItemTemplate(typeof(EnrollmentsViewModel)),
        new ListItemTemplate(typeof(SubjectsViewModel)),
    
    
    };


}
public class ListItemTemplate
{
    public ListItemTemplate(Type type)
    {
        ModelType = type;
        Label = type.Name.Replace("ViewModel", "");
    }
    public string Label { get; }
    public Type ModelType { get; }
}