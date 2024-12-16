using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class DriverStandingViewModel(
    IDriverRepository driverRepo,
    IRaceRepository raceRepo)
    : ObservableObject
{
    private DriverStanding? _model;
    private Race? _race;
    private Driver? _driver;

    public DriverStanding? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                Driver = _model != null ? driverRepo.Get(_model.DriverId) : null;
                Race = _model != null ? raceRepo.Get(_model.RaceId) : null;
            }
        }
    }

    public Race? Race
    {
        get => _race;
        private set => SetProperty(ref _race, value);
    }

    public Driver? Driver
    {
        get => _driver;
        private set => SetProperty(ref _driver, value);
    }
}
