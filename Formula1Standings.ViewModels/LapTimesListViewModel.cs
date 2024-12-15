using CommunityToolkit.Mvvm.ComponentModel;
using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class LapTimesListViewModel(
    IRepository<LapTime> repo
) : ObservableObject
{
    public IList<LapTime> LapTimes { get; } = repo.GetAll();
}
