using System.Windows;
using System.Windows.Controls;
using Formula1Standings.ServiceImplementations;
using Formula1Standings.Services;
using Formula1Standings.UI.Pages;
using Formula1Standings.UI.Services;
using Formula1Standings.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Formula1Standings.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public const string RootFrame = nameof(RootFrame);
    private IServiceProvider _serviceProvider;

    public App()
    {
        _serviceProvider = ConfigureServices();
    }

    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Services
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ICircuitRepository>(new CircuitInMemoryRepository(@"Data\circuits.json"));
        services.AddSingleton<IDriverRepository>(new DriverInMemoryRepository(@"Data\drivers.json"));
        services.AddSingleton<IDriverStandingRepository>(new DriverStandingInMemoryRepository(@"Data\driver_standings.json"));
        services.AddSingleton<IRaceRepository>(new RaceInMemoryRepository(@"Data\races.json"));
        services.AddSingleton<ILapTimeRepository>(new LapTimeInMemoryRepository(@"Data\lap_times.json"));
        services.AddSingleton<IDriverStatsProvider, DriverStatsProvider>();

        // ViewModels
        services.AddTransient<CircuitsListViewModel>();
        services.AddTransient<DriversListViewModel>();
        services.AddTransient<DriverStandingsListViewModel>();
        services.AddTransient<RacesListViewModel>();
        services.AddTransient<LapTimesListViewModel>();
        services.AddTransient<DriverStandingViewModel>();
        services.AddTransient<RaceViewModel>();
        services.AddTransient<LapTimeViewModel>();
        services.AddTransient<CircuitViewModel>();
        services.AddTransient<DriverViewModel>();

        // Pages
        services.AddKeyedSingleton<Page, MainPage>(nameof(MainPage));
        services.AddKeyedSingleton<Page, CircuitsListPage>(nameof(CircuitsListPage));
        services.AddKeyedSingleton<Page, DriversListPage>(nameof(DriversListPage));
        services.AddKeyedSingleton<Page, DriverDetailsPage>(nameof(DriverDetailsPage));
        services.AddKeyedSingleton<Page, DriverStandingsListPage>(nameof(DriverStandingsListPage));
        services.AddKeyedSingleton<Page, RacesListPage>(nameof(RacesListPage));
        services.AddKeyedSingleton<Page, LapTimesListPage>(nameof(LapTimesListPage));

        // Factories
        services.AddTransient<Func<DriverStandingViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<DriverStandingViewModel>());
        services.AddTransient<Func<RaceViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<RaceViewModel>());
        services.AddTransient<Func<LapTimeViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<LapTimeViewModel>());
        services.AddTransient<Func<CircuitViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<CircuitViewModel>());
        services.AddTransient<Func<DriverViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<DriverViewModel>());

        // MainWindow and RootFrame
        services.AddKeyedSingleton(RootFrame, CreateRootFrame());
        services.AddKeyedSingleton<Window, MainWindow>(nameof(MainWindow));

        // Navigation Service
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddKeyedSingleton(NavigationService.DestResolverKey, ResolveNavigationServiceDestination);

        return services.BuildServiceProvider();
    }

    private static Frame CreateRootFrame()
    {
        return new Frame()
        {
            Name = RootFrame,
            NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Visible
        };
    }

    private object? ResolveNavigationServiceDestination(string key, object arg)
    {
        var dest = _serviceProvider.GetKeyedService<Page>(key);
        (dest as INavigatable)?.OnNavigated(arg);
        return dest;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = _serviceProvider.GetKeyedService<Window>(nameof(MainWindow));
        mainWindow!.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        (_serviceProvider as IDisposable)?.Dispose();
    }
}
