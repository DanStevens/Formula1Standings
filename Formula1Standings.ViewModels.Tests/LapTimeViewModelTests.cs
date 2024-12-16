using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class LapTimeViewModelTests
{
    private static readonly Race ExampleRace = new()
    {
        Id = 1,
        Round = 1,
        CircuitId = 1,
        Name = "Example Race",
        Date = new DateOnly(2000, 1, 1),
        Time = "00:00:00",
        Url = new Uri("http://example.com/races/2000_Example")
    };

    private static readonly Driver ExampleDriver = new()
    {
        Id = 1,
        Reference = "example",
        Number = "1",
        Code = "EXA",
        Forename = "John",
        Surname = "Smith",
        DateOfBirth = new DateOnly(1985, 1, 1),
        Nationality = "British",
        Url = new Uri("http://example.com/drivers/John_Smith")
    };

    private static readonly LapTime ExampleLapTime = new()
    {
        RaceId = 1,
        DriverId = 1,
        Lap = 1,
        Position = 1,
        Milliseconds = 60_000,
    };

    [Test]
    public void Model_ShouldReturnExampleLapTime()
    {
        var subject = CreateTestSubject();
        subject.Model.Should().Be(ExampleLapTime);
    }

    [Test]
    public void Driver_ShouldReturnExampleDriver()
    {
        var subject = CreateTestSubject();
        subject.Driver.Should().Be(ExampleDriver);
    }

    [Test]
    public void Race_ShouldReturnExampleRace()
    {
        var subject = CreateTestSubject();
        subject.Race.Should().Be(ExampleRace);
    }

    public static LapTimeViewModel CreateTestSubject()
    {
        return new LapTimeViewModel(CreateMockDriverRepo(), CreateMockRaceRepo())
        {
            Model = ExampleLapTime
        };
    }

    private static IRaceRepository CreateMockRaceRepo()
    {
        var mock = new Mock<IRaceRepository>();
        mock.Setup(x => x.Get(ExampleRace.Id)).Returns(ExampleRace);
        return mock.Object;
    }

    private static IDriverRepository CreateMockDriverRepo()
    {
        var mock = new Mock<IDriverRepository>();
        mock.Setup(x => x.Get(ExampleDriver.Id)).Returns(ExampleDriver);
        return mock.Object;
    }
}
