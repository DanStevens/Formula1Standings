using Formula1Standings.ServiceImplementations;
using Formula1Standings.Services;

namespace Formula1Standings.ServiceImplementation.Tests;

public class DriverStatsProviderTests
{
    private ILapTimeRepository lapTimeRepo = new LapTimeInMemoryRepository(@"Data\lap_times.json");
    private IDriverStandingRepository driverStandingRepo = new DriverStandingInMemoryRepository(@"Data\driver_standings.json");

    [Test]
    public void GetRaceParticipationCount()
    {
        var subject = CreateTestSubject();
        var count = subject.GetRaceParticipationCount(driverId: 1);
        count.Should().Be(327);
    }


    [Test]
    public void GetPodiumsCount()
    {
        var subject = CreateTestSubject();
        var count = subject.GetPodiumsCount(driverId: 1);
        count.Should().Be(233);
    }

    private DriverStatsProvider CreateTestSubject()
    {
        return new DriverStatsProvider(lapTimeRepo, driverStandingRepo);
    }
}
