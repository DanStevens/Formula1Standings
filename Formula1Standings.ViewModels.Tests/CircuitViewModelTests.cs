using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class CircuitViewModelTests
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

    [Test]
    public void Model_ShouldBeExampleCircuit()
    {
        var subject = CreateTestSubject();
        subject.Model.Should().Be(ExampleCircuit);
    }

    private CircuitViewModel CreateTestSubject()
    {
        return new CircuitViewModel()
        {
            Model = ExampleCircuit
        };
    }
}
