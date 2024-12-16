using Formula1Standings.ServiceImplementations;
using Formula1Standings.Services;

namespace Formula1Standings.ServiceImplementation.Tests;

public class DriverStatsProviderTests
{
    private ILapTimeRepository lapTimeRepo = new LapTimeInMemoryRepository(@"Data\lap_times.json");

    [Test]
    public void GetRaceParticipationCount()
    {
        var subject = new DriverStatsProvider(lapTimeRepo);
        var count = subject.GetRaceParticipationCount(driverId: 1);
        count.Should().Be(327);
    }
}
