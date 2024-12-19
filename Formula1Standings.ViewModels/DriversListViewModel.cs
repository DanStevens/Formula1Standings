using Formula1Standings.Services;
using Formula1Standings.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Formula1Standings.ViewModels;

public class DriversListViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private DriverViewModel? _selectedDriver;

    public DriversListViewModel(
        IDriverRepository driverRepo,
        Func<DriverViewModel> driverViewModelFactory,
        INavigationService navigationService)
    {
        NavigateToSelectedDriverDetailsCommand = new RelayCommand(NavigateToSelectedDriverDetails);
        Drivers = driverRepo.GetAll().Select(Wrap).ToArray();
        _navigationService = navigationService;

        DriverViewModel Wrap(Driver driver)
        {
            var vm = driverViewModelFactory();
            vm.Model = driver;
            return vm;
        }
    }

    public ICommand NavigateToSelectedDriverDetailsCommand { get; }

    public IList<DriverViewModel> Drivers { get; }

    public DriverViewModel? SelectedDriver
    {
        get => _selectedDriver;
        set => SetProperty(ref _selectedDriver, value);
    }

    public void NavigateToSelectedDriverDetails()
    {
        if (SelectedDriver?.Model != null)
            _navigationService.Navigate("DriverDetailsPage", SelectedDriver);
    }
}
