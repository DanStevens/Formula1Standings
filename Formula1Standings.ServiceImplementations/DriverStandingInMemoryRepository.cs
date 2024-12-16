using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ServiceImplementations;

public class DriverStandingInMemoryRepository
    : InMemoryRepository<int, DriverStanding>, IDriverStandingRepository
{
    public DriverStandingInMemoryRepository() : base()
    { }

    public DriverStandingInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    protected override int ResolveKey(DriverStanding model)
    {
        return model.Id;
    }
}
