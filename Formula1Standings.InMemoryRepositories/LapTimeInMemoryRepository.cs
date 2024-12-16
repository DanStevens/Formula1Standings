using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class LapTimeInMemoryRepository
    : InMemoryRepository<(int raceId, int driverId, int lap), LapTime>, ILapTimeRepository
{
    private readonly Dictionary<int, IList<LapTime>> raceIndex = new();

    public LapTimeInMemoryRepository() : base()
    { }

    public LapTimeInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    public IList<LapTime> GetByRace(int raceId)
    {
        return raceIndex.TryGetValue(raceId, out var lapTimes) ? lapTimes : Array.Empty<LapTime>();
    }

    protected override (int raceId, int driverId, int lap) ResolveKey(LapTime model)
    {
        return (model.RaceId, model.DriverId, model.Lap);
    }

    protected override void OnRecordLoaded(LapTime model)
    {
        if (raceIndex.TryGetValue(model.RaceId, out var list))
            raceIndex[model.RaceId].Add(model);
        else
            raceIndex.Add(model.RaceId, new List<LapTime>() { model });
    }
}
