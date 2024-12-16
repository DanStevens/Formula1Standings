using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ServiceImplementations;

public class LapTimeInMemoryRepository
    : InMemoryRepository<(int raceId, int driverId, int lap), LapTime>, ILapTimeRepository
{
    private readonly Dictionary<int, IList<LapTime>> raceIndex = new();
    private readonly Dictionary<int, IList<LapTime>> driverIndex = new();

    public LapTimeInMemoryRepository() : base()
    { }

    public LapTimeInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    public IList<LapTime> GetByRace(int raceId)
    {
        return raceIndex.TryGetValue(raceId, out var lapTimes) ? lapTimes : Array.Empty<LapTime>();
    }

    public IList<LapTime> GetByDriver(int driverId)
    {
        return driverIndex.TryGetValue(driverId, out var lapTimes) ? lapTimes: Array.Empty<LapTime>();
    }

    protected override (int raceId, int driverId, int lap) ResolveKey(LapTime model)
    {
        return (model.RaceId, model.DriverId, model.Lap);
    }

    protected override void OnRecordLoaded(LapTime model)
    {
        IndexByRace(model);
        IndexByDriver(model);
    }

    private void IndexByRace(LapTime model)
    {
        if (raceIndex.TryGetValue(model.RaceId, out var list))
            raceIndex[model.RaceId].Add(model);
        else
            raceIndex.Add(model.RaceId, new List<LapTime>() { model });
    }

    private void IndexByDriver(LapTime model)
    {
        if (driverIndex.TryGetValue(model.DriverId, out var list))
            driverIndex[model.DriverId].Add(model);
        else
            driverIndex.Add(model.DriverId, new List<LapTime>() { model });
    }
}
