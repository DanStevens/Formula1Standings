using Formula1Standings.Models;

namespace Formula1Standings.ServiceImplementations.Tests;

public class LapTimeInMemoryRepositoryTests
{
    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new LapTimeInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfLapTimes_WhenGivenPathToLapTimesJson()
    {
        var subject = CreateTestSubject();
        var allLapTimes = subject.GetAll();

        using var _ = new AssertionScope();
        allLapTimes.Should().HaveCount(563636);
        allLapTimes.First().Should().Be(new LapTime()
        {
            RaceId = 841,
            DriverId = 20,
            Lap = 1,
            Position = 1,
            Milliseconds = 98109
        });
        allLapTimes.Last().Should().Be(new LapTime()
        {
            RaceId = 1121,
            DriverId = 807,
            Lap = 56,
            Position = 16,
            Milliseconds = 95602,
        });
    }

    [Test]
    public void GetByRace_ShouldReturnAllLapTimesForGivenRace()
    {
        var subject = CreateTestSubject();
        var lapTimes = subject.GetByRace(1);

        using var _ = new AssertionScope();
        lapTimes.Should().HaveCount(1005);
        lapTimes.First().Should().Be(new LapTime()
        {
            RaceId = 1,
            DriverId = 1,
            Lap = 1,
            Position = 13,
            Milliseconds = 109088
        });
        lapTimes.Last().Should().Be(new LapTime()
        {
            RaceId = 1,
            DriverId = 22,
            Lap = 58,
            Position = 2,
            Milliseconds = 151564,
        });
    }

    private static LapTimeInMemoryRepository CreateTestSubject()
    {
        var subject = new LapTimeInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\lap_times.json");
        return subject;
    }
}
