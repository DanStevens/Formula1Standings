using CommunityToolkit.Mvvm.ComponentModel;
using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriverStandingsListViewModel(
    IRepository<DriverStanding> repo
) : ObservableObject
{
    public IList<DriverStanding> DriverStandings { get; } = repo.GetAll();
}
