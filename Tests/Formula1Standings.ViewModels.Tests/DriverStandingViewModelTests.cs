using Formula1Standings.Services;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class DriverStandingViewModelTests
{
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

    private static readonly DriverStanding ExampleDriverStanding = new()
    {
        Id = 1,
        DriverId = 1,
        RaceId = 1,
        Points = 10.5M,
        Position = 1,
        Wins = 1,
    };

    [Test]
    public void Driver_ShouldReturnExampleDriver()
    {
        var subject = CreateTestSubject();
        subject.Driver.Should().BeSameAs(ExampleDriver);
    }

    [Test]
    public void Race_ShouldReturnExampleRace()
    {
        var subject = CreateTestSubject();
        subject.Race.Should().BeSameAs(ExampleRace);
    }

    private static DriverStandingViewModel CreateTestSubject()
    {
        return new DriverStandingViewModel(CreateMockDriverRepo(), CreateMockRaceRepo())
        {
            Model = ExampleDriverStanding,
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
