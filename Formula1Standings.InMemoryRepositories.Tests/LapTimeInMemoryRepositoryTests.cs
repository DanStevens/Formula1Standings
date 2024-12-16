using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

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
        var subject = new LapTimeInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\lap_times.json");

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
}
