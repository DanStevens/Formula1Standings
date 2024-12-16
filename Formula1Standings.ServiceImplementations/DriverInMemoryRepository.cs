using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ServiceImplementations;

public class DriverInMemoryRepository
    : InMemoryRepository<int, Driver>, IDriverRepository
{
    public DriverInMemoryRepository() : base()
    { }

    public DriverInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    protected override int ResolveKey(Driver model)
    {
        return model.Id;
    }
}
