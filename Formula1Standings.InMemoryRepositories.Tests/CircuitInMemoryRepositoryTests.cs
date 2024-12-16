using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

public class CircuitInMemoryRepositoryTests
{
    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new CircuitInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfCircuits_WhenGivenPathToCircuitsJson()
    {
        var subject = new CircuitInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\circuits.json");
        
        var allCircuits = subject.GetAll();

        using var _ = new AssertionScope();
        allCircuits.Should().HaveCount(77);
        allCircuits.First().Should().Be(new Circuit()
        {
            Id = 1,
            Reference = "albert_park",
            Name = "Albert Park Grand Prix Circuit",
            City = "Melbourne",
            Country = "Australia",
            Latitude = -37.8497,
            Longitute = 144.968,
            Altitude = 10,
            Url = new Uri("http://en.wikipedia.org/wiki/Melbourne_Grand_Prix_Circuit")
        });
        allCircuits.Last().Should().Be(new Circuit()
        {
            Id = 79,
            Reference = "miami",
            Name = "Miami International Autodrome",
            City = "Miami",
            Country = "USA",
            Latitude = 25.9581,
            Longitute = -80.2389,
            Altitude = 0,
            Url = new Uri("http://en.wikipedia.org/wiki/Miami_International_Autodrome")
        });
    }
}
