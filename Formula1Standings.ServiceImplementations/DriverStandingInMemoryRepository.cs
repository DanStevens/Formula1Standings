using Formula1Standings.Services;
using Formula1Standings.Models;
using System.ComponentModel;

namespace Formula1Standings.ServiceImplementations;

public class DriverStandingInMemoryRepository
    : InMemoryRepository<int, DriverStanding>, IDriverStandingRepository
{
    private Dictionary<int, IList<DriverStanding>> _driverIndex = new();

    public DriverStandingInMemoryRepository() : base()
    { }

    public DriverStandingInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    public IList<DriverStanding> GetByDriver(int driverId)
    {
        return _driverIndex.TryGetValue(driverId, out var standings) ? standings : Array.Empty<DriverStanding>();
    }

    protected override int ResolveKey(DriverStanding model)
    {
        return model.Id;
    }

    protected override void OnRecordLoaded(DriverStanding model)
    {
        if (_driverIndex.TryGetValue(model.DriverId, out var list))
            _driverIndex[model.DriverId].Add(model);
        else
            _driverIndex.Add(model.DriverId, new List<DriverStanding>() { model });
    }
}
