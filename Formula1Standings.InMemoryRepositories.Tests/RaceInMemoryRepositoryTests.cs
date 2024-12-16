using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

public class RaceInMemoryRepositoryTests
{
    private Race Race1 = new()
    {
        Id = 1,
        Round = 1,
        CircuitId = 1,
        Name = "Australian Grand Prix",
        Date = new DateOnly(2009, 03, 29),
        Time = "06:00:00",
        Url = new Uri("http://en.wikipedia.org/wiki/2009_Australian_Grand_Prix")
    };

    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new RaceInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfRaces_WhenGivenPathToRacesJson()
    {
        var subject = CreateTestSubject();
        
        var allRaces = subject.GetAll();

        using var _ = new AssertionScope();
        allRaces.Should().HaveCount(1125);
        allRaces.First().Should().Be(Race1);
        allRaces.Last().Should().Be(new Race()
        {
            Id = 1144,
            Round = 24,
            CircuitId = 24,
            Name = "Abu Dhabi Grand Prix",
            Date = new DateOnly(2024, 12, 08),
            Time = "\\N",
            Url = new Uri("https://en.wikipedia.org/wiki/2024_Abu_Dhabi_Grand_Prix")
        });
    }

    [Test]
    public void Get_ShouldReturnRaceWithGivenId()
    {
        var subject = CreateTestSubject();
        var race = subject.Get(1);
        race.Should().Be(Race1);
    }

    [Test]
    public void GetByCircuit_ShouldReturnAllRacesForGivenCircuit()
    {
        var subject = CreateTestSubject();
        var races = subject.GetByCircuit(1);
        
        using var _ = new AssertionScope();
        races.Should().HaveCount(27);
        races.First().Should().Be(new Race()
        {
            Id = 1,
            CircuitId = 1,
            Name = "Australian Grand Prix",
            Round = 1,
            Date = new DateOnly(2009, 3, 29),
            Time = "06:00:00",
            Url = new Uri("http://en.wikipedia.org/wiki/2009_Australian_Grand_Prix"),
        });
        races.Last().Should().Be(new Race()
        {
            Id = 1123,
            CircuitId = 1,
            Name = "Australian Grand Prix",
            Round = 3,
            Date = new DateOnly(2024, 3, 24),
            Time = "\\N",
            Url = new Uri("https://en.wikipedia.org/wiki/2024_Australian_Grand_Prix"),
        });
    }

    private static RaceInMemoryRepository CreateTestSubject()
    {
        var subject = new RaceInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\races.json");
        return subject;
    }
}
