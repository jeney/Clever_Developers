using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Uni_Man_App.ViewModels;

namespace Uni_Man_App.Views;

public partial class StudentWindow : Window
{
    public StudentWindow()
    {
        InitializeComponent();
        DataContext = new StudentWindowViewModel(); // Ensure ViewModel is set
    }
    
    private void LogOut_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();  // Opens StudentWindow
        this.Close();          // Closes MainWindow
    }
}