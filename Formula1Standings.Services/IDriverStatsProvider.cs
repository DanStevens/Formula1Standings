using Formula1Standings.Models;

namespace Formula1Standings.Services;

public interface IDriverStatsProvider
{
    int GetRaceParticipationCount(int driverId);
}
