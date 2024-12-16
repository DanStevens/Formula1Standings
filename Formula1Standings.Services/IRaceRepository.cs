using Formula1Standings.Models;

namespace Formula1Standings.Services;

public interface IRaceRepository : IRepository<int, Race>
{
    IList<Race> GetByCircuit(int circuitId);
}
