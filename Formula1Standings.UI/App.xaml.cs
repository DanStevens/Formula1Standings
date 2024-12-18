﻿using Formula1Standings.Services;
using Formula1Standings.ServiceImplementations;
using Formula1Standings.UI.Pages;
using Formula1Standings.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddSingleton<MainPage>();
        services.AddKeyedSingleton<Page, CircuitsListPage>(nameof(CircuitsListPage));
        services.AddKeyedSingleton<Page, DriversListPage>(nameof(DriversListPage));
        services.AddKeyedSingleton<Page, DriverStandingsListPage>(nameof(DriverStandingsListPage));
        services.AddKeyedSingleton<Page, RacesListPage>(nameof(RacesListPage));
        services.AddKeyedSingleton<Page, LapTimesListPage>(nameof(LapTimesListPage));

        // Factories
        services.AddTransient<Func<DriverStandingViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<DriverStandingViewModel>());
        services.AddTransient<Func<RaceViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<RaceViewModel>());
        services.AddTransient<Func<LapTimeViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<LapTimeViewModel>());
        services.AddTransient<Func<CircuitViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<CircuitViewModel>());
        services.AddTransient<Func<DriverViewModel>>(serviceProvider => () => serviceProvider.GetRequiredService<DriverViewModel>());

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
