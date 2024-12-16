using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class DriverViewModelTests
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

    [Test]
    public void Model_ShouldBeExampleDriver()
    {
        var subject = CreateTestSubject();
        subject.Model.Should().Be(ExampleDriver);
    }

    private static DriverViewModel CreateTestSubject()
    {
        return new DriverViewModel() { Model = ExampleDriver };
    }
}
