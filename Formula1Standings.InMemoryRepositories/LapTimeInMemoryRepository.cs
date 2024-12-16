using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class LapTimeInMemoryRepository
    : InMemoryRepository<(int raceId, int driverId, int lap), LapTime>, ILapTimeRepository
{
    public LapTimeInMemoryRepository() : base()
    { }

    public LapTimeInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    protected override (int raceId, int driverId, int lap) ResolveKey(LapTime model)
    {
        return (model.RaceId, model.DriverId, model.Lap);
    }
}
