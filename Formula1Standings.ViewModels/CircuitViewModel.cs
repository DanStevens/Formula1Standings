using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class CircuitViewModel(
    IRaceRepository raceRepo,
    ILapTimeRepository lapTimeRepo,
    Func<LapTimeViewModel> lapTimeViewModelFactory)
    : ObservableObject
{
    private Circuit? _model;
    private IList<Race> _races = Array.Empty<Race>();
    private LapTimeViewModel? _fastestLap;

    public Circuit? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                Races = _model != null ? raceRepo.GetByCircuit(_model.Id) : Array.Empty<Race>();
                FastestLap = _model != null ? Wrap(FindFastestLap()) : null;
            }
        }
    }

    public IList<Race> Races
    {
        get => _races;
        set => SetProperty(ref _races, value);
    }

    public LapTimeViewModel? FastestLap
    {
        get => _fastestLap;
        set => SetProperty(ref _fastestLap, value);
    }

    private LapTime? FindFastestLap()
    {
        if (Races == null)
            return null;

        return Races.SelectMany(r => lapTimeRepo.GetByRace(r.Id))
                    .OrderBy(r => r.Time).FirstOrDefault();
    }

    private LapTimeViewModel? Wrap(LapTime? model)
    {
        if (model == null)
            return null;
        var vm = lapTimeViewModelFactory();
        vm.Model = model;
        return vm;
    }
}
