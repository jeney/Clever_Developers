using System.ComponentModel;
using System.Windows.Input;
using rest_sim.Models;
using rest_sim.ViewModels;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace rest_sim.ViewModels;

public class RecipeProgressViewModel : INotifyPropertyChanged{
    private string _currentStep = "";
    private double _progressPercentage;
    private bool _isCompleted;

    public Recipe Recipe { get; }

    public string CurrentStep{
        get => _currentStep;
        set{
            _currentStep = value;
            OnPropertyChanged(nameof(CurrentStep));
        }
    }

    public double ProgressPercentage{
        get => _progressPercentage;
        set{
            _progressPercentage = value;
            OnPropertyChanged(nameof(ProgressPercentage));
        }
    }

    public bool IsCompleted{
        get => _isCompleted;
        set{
            _isCompleted = value;
            OnPropertyChanged(nameof(IsCompleted));
        }
    }

    public RecipeProgressViewModel(Recipe recipe){
        Recipe = recipe;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}