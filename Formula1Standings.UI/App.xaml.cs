using Formula1Standings.DataAccess;
using Formula1Standings.InMemoryRepositories;
using Formula1Standings.UI.Views;
using Formula1Standings.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Formula1Standings.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; }

    public new static App Current => (App)Application.Current;

    public App() : base()
    {
        ServiceProvider = ConfigureServices();
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

        return services.BuildServiceProvider();
    }
}
