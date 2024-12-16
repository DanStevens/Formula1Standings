using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

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
