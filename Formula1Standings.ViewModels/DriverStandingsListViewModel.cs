using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriverStandingsListViewModel(
    IDriverStandingRepository repo
) : ObservableObject
{
    public IList<DriverStanding> DriverStandings { get; } = repo.GetAll();
}
