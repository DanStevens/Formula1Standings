using Formula1Standings.Models;

namespace Formula1Standings.Services;

public interface ILapTimeRepository
    : IRepository<(int raceId, int driverId, int lap), LapTime>
{
    IList<LapTime> GetByRace(int raceId);

    IList<LapTime> GetByDriver(int driverId);
}
