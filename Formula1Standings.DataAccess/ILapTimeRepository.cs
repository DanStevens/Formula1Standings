using Formula1Standings.Models;

namespace Formula1Standings.DataAccess;

public interface ILapTimeRepository
    : IRepository<(int raceId, int driverId, int lap), LapTime>
{
}
