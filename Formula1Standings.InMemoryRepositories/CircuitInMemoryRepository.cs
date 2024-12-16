using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class CircuitInMemoryRepository
    : InMemoryRepository<int, Circuit>, ICircuitRepository
{
    public CircuitInMemoryRepository() : base()
    { }

    public CircuitInMemoryRepository(string initialDataPath) 
        : base(initialDataPath)
    { }

    protected override int ResolveKey(Circuit value)
    {
        return value.Id;
    }
}
