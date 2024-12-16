using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class LapTimeViewModel(
    IDriverRepository driverRepo,
    IRaceRepository raceRepo)
    : ObservableObject
{
    private LapTime? _model;
    private Race? _race;
    private Driver? _driver;

    public LapTime? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                Race = _model != null ? raceRepo.Get(_model.RaceId) : null;
                Driver = _model != null ? driverRepo?.Get(_model.DriverId) : null;
            }
        }
    }

    public Driver? Driver
    {
        get => _driver;
        set => SetProperty(ref _driver, value);
    }

    public Race? Race
    {
        get => _race;
        set => SetProperty(ref _race, value);
    }
}
