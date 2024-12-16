using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriverStandingsListViewModel : ObservableObject
{
    public DriverStandingsListViewModel(
        IDriverStandingRepository repo,
        Func<DriverStandingViewModel> driverStandingViewModelFactory)
    {
        DriverStandings = repo.GetAll().Select(Wrap).ToArray();

        DriverStandingViewModel Wrap(DriverStanding driverStanding)
        {
            var vm = driverStandingViewModelFactory();
            vm.Model = driverStanding;
            return vm;
        }
    }

    public IList<DriverStandingViewModel> DriverStandings { get; }

}
