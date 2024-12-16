using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriversListViewModel(
    IDriverRepository repo
) : ObservableObject
{
    public IList<Driver> Drivers { get; } = repo.GetAll();
}
