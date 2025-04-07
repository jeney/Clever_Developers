using Avalonia.Controls;
using Avalonia.Input;
using Avalonia;
using System;
using System.IO;
using System.Threading.Tasks;
using Data_vis.ViewModels;

namespace Data_vis.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_DragOver(object? sender, DragEventArgs e)
    {
        if (e.Data.Contains(DataFormats.Files))
        {
            e.DragEffects = DragDropEffects.Copy;
        }
        else
        {
            e.DragEffects = DragDropEffects.None;
        }
        e.Handled = true;
    }

    private async void Window_Drop(object? sender, DragEventArgs e)
    {
        if (e.Data.Contains(DataFormats.Files))
        {
            var files = e.Data.Get(DataFormats.Files) as string[];
            if (files != null)
            {
                foreach (var file in files)
                {
                    await HandleFileAsync(file); // not filePath!
                }
            }
        }
    }

    private async Task HandleFileAsync(string filePath)
    {
        string content = await File.ReadAllTextAsync(filePath);
        if (DataContext is MainWindowViewModel vm)
        {
            vm.Items.Add($"Dropped: {Path.GetFileName(filePath)}");
        }
    }
}
