using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

public class DriverStandingInMemoryRepositoryTests
{
    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new DriverStandingInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfStandings_WhenGivenPathToDriverStandingsJson()
    {
        var subject = new DriverStandingInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\driver_standings.json");
        
        var allStandings = subject.GetAll();

        using var _ = new AssertionScope();
        allStandings.Should().HaveCount(34364);
        allStandings.First().Should().Be(new DriverStanding()
        {
            Id = 1,
            RaceId = 18,
            DriverId = 1,
            Points = 10,
            Position = 1,
            Wins = 1,
        });
        allStandings.Last().Should().Be(new DriverStanding()
        {
            Id = 72577,
            RaceId = 1121,
            DriverId = 858,
            Points = 0,
            Position = 20,
            Wins = 0,
        });
    }
}
