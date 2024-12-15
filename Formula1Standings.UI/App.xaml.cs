using Formula1Standings.DataAccess;
using Formula1Standings.InMemoryRepositories;
using Formula1Standings.UI.Pages;
using Formula1Standings.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Formula1Standings.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;
    private MainWindow _mainWindow;

    public App()
    {
        _serviceProvider = ConfigureServices();
        _mainWindow = new MainWindow();
    }

    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Services
        var circuitsRepository = new CircuitInMemoryRepository();
        circuitsRepository.LoadFromJsonFile(@"Data\circuits.json");
        services.AddSingleton<ICircuitRepository>(circuitsRepository);

        // ViewModels
        services.AddTransient<CircuitsListViewModel>();

        // Pages
        services.AddSingleton<MainPage>();
        services.AddKeyedSingleton<Page, CircuitsListPage>(nameof(CircuitsListPage));

        return services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainPage = _serviceProvider.GetService<MainPage>()!;
        mainPage.NavigationRequested += HandleNavigationRequest;
        _mainWindow.Navigate(mainPage);
        _mainWindow.Show();
    }

    private void HandleNavigationRequest(object? sender, NavigationEventArgs e)
    {
        var page = _serviceProvider.GetKeyedService<Page>(e.Key);
        if (page != null)
            _mainWindow.Navigate(page);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        (_serviceProvider as IDisposable)?.Dispose();
    }
}
