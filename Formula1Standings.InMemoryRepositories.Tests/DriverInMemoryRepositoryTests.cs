using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

public class DriverInMemoryRepositoryTests
{
    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new DriverInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfDrivers_WhenGivenPathToDriversJson()
    {
        var subject = new DriverInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\drivers.json");
        
        var allDrivers = subject.GetAll();

        using var _ = new AssertionScope();
        allDrivers.Should().HaveCount(858);
        allDrivers.First().Should().Be(new Driver()
        {
            Id = 1,
            Reference = "hamilton",
            Number = "44",
            Code = "HAM",
            Forename = "Lewis",
            Surname = "Hamilton",
            DateOfBirth = new DateOnly(1985, 1, 7),
            Nationality = "British",
            Url = new Uri("http://en.wikipedia.org/wiki/Lewis_Hamilton"),
        });
        allDrivers.Last().Should().Be(new Driver()
        {
            Id = 859,
            Reference = "lawson",
            Number = "40",
            Code = "LAW",
            Forename = "Liam",
            Surname = "Lawson",
            DateOfBirth = new DateOnly(2002, 2, 11),
            Nationality = "New Zealander",
            Url = new Uri("http://en.wikipedia.org/wiki/Liam_Lawson"),
        });
    }
}
