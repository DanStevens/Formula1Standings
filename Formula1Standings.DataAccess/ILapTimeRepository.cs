using Formula1Standings.Models;

namespace Formula1Standings.DataAccess;

public interface ILapTimeRepository
    : IRepository<(int raceId, int driverId, int lap), LapTime>
{
    IList<LapTime> GetByRace(int raceId);
}
