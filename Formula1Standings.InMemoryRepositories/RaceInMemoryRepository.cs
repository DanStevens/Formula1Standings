using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class RaceInMemoryRepository
    : InMemoryRepository<int, Race>, IRaceRepository
{
    public RaceInMemoryRepository() : base()
    { }

    public RaceInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    protected override int ResolveKey(Race model)
    {
        return model.Id;
    }
}
