using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class LapTimesListViewModel : ObservableObject
{
    public LapTimesListViewModel(
        ILapTimeRepository repo,
        Func<LapTimeViewModel> lapTimeViewModelFactory
)
    {
        LapTimes = repo.GetAll().Select(Wrap).ToArray();

        LapTimeViewModel Wrap(LapTime lapTime)
        {
            var vm = lapTimeViewModelFactory();
            vm.Model = lapTime;
            return vm;
        }
    }

    public IList<LapTimeViewModel> LapTimes { get; }
}
