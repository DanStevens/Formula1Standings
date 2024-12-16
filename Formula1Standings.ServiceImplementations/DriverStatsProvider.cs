using Formula1Standings.Services;

namespace Formula1Standings.ServiceImplementations;

public class DriverStatsProvider(
    ILapTimeRepository lapTimeRepo,
    IDriverStandingRepository driverStandingRepo)
: IDriverStatsProvider
{
    public int GetRaceParticipationCount(int driverId)
    {
        var driverLapTimes = lapTimeRepo.GetByDriver(driverId);
        return driverLapTimes.DistinctBy(l => l.RaceId).Count();
    }

    public int GetPodiumsCount(int driverId)
    {
        var standings = driverStandingRepo.GetByDriver(driverId);
        return standings.Count(s => s.Position <= 3);
    }
}
