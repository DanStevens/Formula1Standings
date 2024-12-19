using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Formula1Standings.Services;
using Formula1Standings.UI.Pages;

namespace Formula1Standings.UI;

public partial class MainWindow : Window
{
    private readonly INavigationService? _navigationService;

    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(
        [FromKeyedServices(App.RootFrame)] Frame rootFrame,
        INavigationService navigationService)
        : this()
    {
        _navigationService = navigationService;
        AddChild(rootFrame);
    }

    protected override void OnContentRendered(EventArgs e)
    {
        base.OnContentRendered(e);
        _navigationService?.Navigate(nameof(MainPage));
    }
}