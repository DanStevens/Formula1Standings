using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class RaceViewModelTests
{
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

    [Test]
    public void Model_ShouldBeExampleRace()
    {
        var subject = CreateTestSubect();
        subject.Model.Should().Be(ExampleRace);
    }

    [Test]
    public void Circuit_ShouldBeExampleCircuit()
    {
        var subject = CreateTestSubect();
        subject.Circuit.Should().Be(ExampleCircuit);
    }

    private static RaceViewModel CreateTestSubect()
    {
        return new RaceViewModel(CreateMockCircuitRepo())
        {
            Model = ExampleRace
        };
    }

    private static ICircuitRepository CreateMockCircuitRepo()
    {
        var mock = new Mock<ICircuitRepository>();
        mock.Setup(x => x.Get(ExampleCircuit.Id)).Returns(ExampleCircuit);
        return mock.Object;
    }
}
