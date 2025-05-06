using Avalonia.Controls;

namespace Uni_Man_App.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void LoginAsStudent_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var studentWindow = new StudentWindow();
        studentWindow.Show();  // Opens StudentWindow
        this.Close();          // Closes MainWindow
    }
    
    private void LoginAsTeacher_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var teacherWindow = new TeacherWindow();
        teacherWindow.Show(); 
        this.Close();          // Closes MainWindow
    }
    
}