using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriversListViewModel : ObservableObject
{
    public DriversListViewModel(
        IDriverRepository driverRepo,
        Func<DriverViewModel> driverViewModelFactory)
    {
        Drivers = driverRepo.GetAll().Select(Wrap).ToArray();

        DriverViewModel Wrap(Driver driver)
        {
            var vm = driverViewModelFactory();
            vm.Model = driver;
            return vm;
        }
    }

    public IList<DriverViewModel> Drivers { get; }

}
