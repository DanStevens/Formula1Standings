using Formula1Standings.Models;
using Formula1Standings.Services;

namespace Formula1Standings.ViewModels;

public class DriverViewModel(
    IDriverStatsProvider driverStatsProvider)
    : ObservableObject
{
    private Driver? _model;
    private int _racePartipicationCount;
    private int _podiumsCount;

    public Driver? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                RacePartipicationCount = _model != null
                    ? driverStatsProvider.GetRaceParticipationCount(_model.Id)
                    : 0;
                PodiumsCount = _model != null
                    ? driverStatsProvider.GetPodiumsCount(_model.Id)
                    : 0;
            }
        }
    }

    public int RacePartipicationCount
    {
        get => _racePartipicationCount;
        set => SetProperty(ref _racePartipicationCount, value);
    }

    public int PodiumsCount
    {
        get => _podiumsCount;
        set => SetProperty(ref _podiumsCount, value);
    }
}
