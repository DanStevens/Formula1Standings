using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class CircuitViewModelTests
{
    private static readonly LapTime[] ExampleLapTimes = [
        new()
        {
            DriverId = 1,
            RaceId = 1,
            Lap = 1,
            Position = 1,
            Milliseconds = 30000,
        },
        new()
        {
            DriverId = 2,
            RaceId = 1,
            Lap = 1,
            Position = 2,
            Milliseconds = 31000,
        },
        new()
        {
            DriverId = 3,
            RaceId = 1,
            Lap = 1,
            Position = 3,
            Milliseconds = 32000,
        },
        new()
        {
            DriverId = 1,
            RaceId = 2,
            Lap = 1,
            Position = 1,
            Milliseconds = 33000,
        },
        new()
        {
            DriverId = 2,
            RaceId = 2,
            Lap = 1,
            Position = 2,
            Milliseconds = 34000,
        },
        new()
        {
            DriverId = 3,
            RaceId = 2,
            Lap = 1,
            Position = 3,
            Milliseconds = 35000,
        },
                new()
        {
            DriverId = 1,
            RaceId = 3,
            Lap = 1,
            Position = 1,
            Milliseconds = 36000,
        },
        new()
        {
            DriverId = 2,
            RaceId = 3,
            Lap = 1,
            Position = 2,
            Milliseconds = 37000,
        },
        new()
        {
            DriverId = 3,
            RaceId = 3,
            Lap = 1,
            Position = 3,
            Milliseconds = 38000,
        },
    ];

    private static readonly Race[] ExampleRaces = [
        new()
        {
            Id = 1,
            Round = 1,
            CircuitId = 1,
            Name = "Example Race 1",
            Date = new DateOnly(2000, 1, 1),
            Time = "00:00:00",
            Url = new Uri("http://example.com/races/2000_Example1")
        },
        new()
        {
            Id = 2,
            Round = 2,
            CircuitId = 1,
            Name = "Example Race 2",
            Date = new DateOnly(2000, 1, 2),
            Time = "00:00:00",
            Url = new Uri("http://example.com/races/2000_Example2")
        },
        new()
        {
            Id = 3,
            Round = 3,
            CircuitId = 1,
            Name = "Example Race 3",
            Date = new DateOnly(2000, 1, 3),
            Time = "00:00:00",
            Url = new Uri("http://example.com/races/2000_Example3")
        }
    ];

    private static readonly Circuit ExampleCircuit = new()
    {
        Id = 1,
        Reference = "example",
        Name = "Example Circuit",
        City = "Example City",
        Country = "Example Country",
        Latitude = 1d,
        Longitute = 1d,
        Altitude = 1,
        Url = new Uri("http://example.com/circuits/example")
    };

    private IRaceRepository raceRepo = CreateMockRaceRepo();

    [Test]
    public void Model_ShouldBeExampleCircuit()
    {
        var subject = CreateTestSubject();
        subject.Model.Should().Be(ExampleCircuit);
    }

    [Test]
    public void Races_ShouldReturnAllRacesAtGivenCircuit()
    {
        var subject = CreateTestSubject();
        subject.Races.Should().BeEquivalentTo(ExampleRaces);
    }

    [Test]
    public void FastestLap_ShouldReturnTimeOfFastestLap()
    {
        var subject = CreateTestSubject();
        var expected = CreateLapTimeViewModel(ExampleLapTimes[0]);
        subject.FastestLap.Should().BeEquivalentTo(expected);
    }

    private CircuitViewModel CreateTestSubject()
    {
        return new CircuitViewModel(
            raceRepo,
            CreateMockLapTimeReport(),
            () => CreateLapTimeViewModel(null))
        {
            Model = ExampleCircuit
        };
    }

    private LapTimeViewModel CreateLapTimeViewModel(LapTime? model)
    {
        var lapTimeViewModel = new LapTimeViewModel(Mock.Of<IDriverRepository>(), raceRepo);
        lapTimeViewModel.Model = model;
        return lapTimeViewModel;
    }

    private static IRaceRepository CreateMockRaceRepo()
    {
        var mock = new Mock<IRaceRepository>();
        mock.Setup(x => x.GetByCircuit(1)).Returns(ExampleRaces);

        foreach (var race in ExampleRaces)
            mock.Setup(x => x.Get(race.Id)).Returns(race);
        
        return mock.Object;
    }

    private static ILapTimeRepository CreateMockLapTimeReport()
    {
        var mock = new Mock<ILapTimeRepository>();
        mock.Setup(x => x.GetAll()).Returns(ExampleLapTimes);
        mock.Setup(x => x.GetByRace(1)).Returns(ExampleLapTimes.Where(lt => lt.RaceId == 1).ToArray);
        mock.Setup(x => x.GetByRace(2)).Returns(ExampleLapTimes.Where(lt => lt.RaceId == 2).ToArray);
        mock.Setup(x => x.GetByRace(3)).Returns(ExampleLapTimes.Where(lt => lt.RaceId == 3).ToArray);
        return mock.Object;
    }
}
