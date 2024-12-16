using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class RacesListViewModel : ObservableObject
{
    public RacesListViewModel(
        IRaceRepository repo,
        Func<RaceViewModel> raceViewModelFactory)
    {
        Races = repo.GetAll().Select(Wrap).ToArray();

        RaceViewModel Wrap(Race race)
        {
            var vm = raceViewModelFactory();
            vm.Model = race;
            return vm;
        }
    }

    public IList<RaceViewModel> Races { get; }


}
