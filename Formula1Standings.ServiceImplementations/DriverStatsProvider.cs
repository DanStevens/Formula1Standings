using Formula1Standings.Models;
using Formula1Standings.Services;

namespace Formula1Standings.ServiceImplementations;

public class DriverStatsProvider(
    ILapTimeRepository lapTimeRepo)
: IDriverStatsProvider
{
    public int GetRaceParticipationCount(int driverId)
    {
        var driverLapTimes = lapTimeRepo.GetByDriver(driverId);
        return driverLapTimes.DistinctBy(l => l.RaceId).Count();
    }
}
