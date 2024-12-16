using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class CircuitViewModelTests
{
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

    private CircuitViewModel CreateTestSubject()
    {
        return new CircuitViewModel(CreateMockRaceRepo())
        {
            Model = ExampleCircuit
        };
    }

    private static IRaceRepository CreateMockRaceRepo()
    {
        var mock = new Mock<IRaceRepository>();
        mock.Setup(x => x.GetByCircuit(1)).Returns(ExampleRaces);

        foreach (var race in ExampleRaces)
            mock.Setup(x => x.Get(race.Id)).Returns(race);
        
        return mock.Object;
    }
}
