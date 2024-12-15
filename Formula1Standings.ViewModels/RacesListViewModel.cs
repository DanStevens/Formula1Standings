using CommunityToolkit.Mvvm.ComponentModel;
using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class RacesListViewModel(
    IRepository<Race> repo
) : ObservableObject
{
    public IList<Race> Races { get; } = repo.GetAll();
}
