using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Threading;
using System.ComponentModel;
using rest_sim.Models;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace rest_sim.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
	[RelayCommand]
    private async Task StartSimulation()
    {
		try
		{
        	var (_, recipes) = RecipeLoaderService.LoadRecipes("ExerciseJson.json");
        	await StartSimulationAsync(recipes);
		}
		catch (Exception ex){
			Console.WriteLine($"Error loading recipes: {ex.Message}");
			 Console.WriteLine($"Inner Error: {ex.InnerException?.Message}");
		}

    }

    public ObservableCollection<RecipeProgressViewModel> ActiveRecipes { get; } = new();
    public async Task StartSimulationAsync(List<Recipe> recipes)
    {
        foreach (var recipe in recipes)
        {
            var progressVM = new RecipeProgressViewModel(recipe);
            ActiveRecipes.Add(progressVM);
            await Task.Run(() => SimulateRecipe(progressVM));
        }
    }

    private async Task SimulateRecipe(RecipeProgressViewModel progressVM)
    {
        foreach (var step in progressVM.Recipe.Steps)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
                progressVM.CurrentStep = step.Step
            );

            for (int i = 0; i < step.Duration; i++)
            {
                await Task.Delay(1000);
                await Dispatcher.UIThread.InvokeAsync(() =>
                    progressVM.ProgressPercentage = (i + 1) / (double)step.Duration * 100
                );
            }
        }
        await Dispatcher.UIThread.InvokeAsync(() =>
            progressVM.IsCompleted = true
        );
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}