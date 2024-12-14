using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class CircuitInMemoryRepository
    : InMemoryRepository<Circuit>, ICircuitRepository
{
}
