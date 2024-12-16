using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class CircuitViewModel(
    IRaceRepository raceRepo)
    : ObservableObject
{
    private Circuit? _model;
    private IList<Race> _races = Array.Empty<Race>();

    public Circuit? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                Races = _model != null ? raceRepo.GetByCircuit(_model.Id) : Array.Empty<Race>();
            }
        }
    }

    public IList<Race> Races
    {
        get => _races;
        set => SetProperty(ref _races, value);
    }
}
