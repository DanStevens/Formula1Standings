using Formula1Standings.Models;

namespace Formula1Standings.Services;

public interface IDriverStandingRepository : IRepository<int, DriverStanding>
{
    IList<DriverStanding> GetByDriver(int driverId);
}
