using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories;

public class RaceInMemoryRepository
    : InMemoryRepository<int, Race>, IRaceRepository
{
    private readonly Dictionary<int, IList<Race>> circuitIndex = new();

    public RaceInMemoryRepository() : base()
    { }

    public RaceInMemoryRepository(string initialDataPath)
        : base(initialDataPath)
    { }

    public IList<Race> GetByCircuit(int circuitId)
    {
        return circuitIndex[circuitId];
    }

    protected override int ResolveKey(Race model)
    {
        return model.Id;
    }

    protected override void OnRecordLoaded(Race model)
    {
        if (circuitIndex.TryGetValue(model.CircuitId, out var list))
            circuitIndex[model.CircuitId].Add(model);
        else
            circuitIndex.Add(model.CircuitId, new List<Race> { model });
    }
}
