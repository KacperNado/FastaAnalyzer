using Avalonia.Controls;
using FastaAnalyzer.ViewModels;

namespace FastaAnalyzer;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }
}