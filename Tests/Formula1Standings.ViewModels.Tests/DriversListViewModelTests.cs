using Formula1Standings.Models;
using Formula1Standings.Services;

namespace Formula1Standings.ViewModels.Tests;

public class DriversListViewModelTests
{
    private static readonly Driver[] ExampleDrivers = [
        new Driver()
        {
            Id = 848,
            Reference = "albon",
            Number = "23",
            Code = "ALB",
            Forename = "Alexander",
            Surname = "Albon",
            DateOfBirth = new DateOnly(1996, 3, 23),
            Nationality = "Thai",
            Url = new Uri("http://en.wikipedia.org/wiki/Alexander_Albon")
        },
        new Driver()
        {
            Id = 858,
            Reference = "sargeant",
            Number = "2",
            Code = "SAR",
            Forename = "Logan",
            Surname = "Sargean",
            DateOfBirth = new DateOnly(2000, 12, 31),
            Nationality = "American",
            Url = new Uri("http://en.wikipedia.org/wiki/Logan_Sargeant")
        }
    ];

    private IDriverStatsProvider _driverStatsProviderMock = Mock.Of<IDriverStatsProvider>();

    [Test]
    public void NavigateToSelectedDriverDetails_ShouldInvokeNavigateMethodOnNavigationService_WhenDriverIsSelected()
    {
        var driver = ExampleDrivers[0];
        var navigationServiceMock = new Mock<INavigationService>();
        var subject = CreateTestSubject(navigationServiceMock.Object);
        subject.SelectedDriver = Wrap(driver);
        
        subject.NavigateToSelectedDriverDetails();
        
        navigationServiceMock.Verify(x => x.Navigate("DriverDetailsPage", driver.Id));
    }

    [Test]
    public void NavigateToSelectedDriverDetails_ShouldNotInvokeNavigationService_WhenNoDriverIsSelected()
    {
        var navigationServiceMock = new Mock<INavigationService>();
        var subject = CreateTestSubject(navigationServiceMock.Object);
        subject.SelectedDriver.Should().BeNull();

        subject.NavigateToSelectedDriverDetails();

        navigationServiceMock.Verify(x => x.Navigate(It.IsAny<string>(), It.IsAny<object?>()), Times.Never);
    }

    private DriversListViewModel CreateTestSubject(INavigationService navigationService)
    {
        var driverRepoMock = new Mock<IDriverRepository>();
        driverRepoMock.Setup(x => x.GetAll()).Returns(ExampleDrivers);

        return new DriversListViewModel(
            driverRepoMock.Object,
            () => new DriverViewModel(_driverStatsProviderMock),
            navigationService);
    }

    private DriverViewModel Wrap(Driver driver)
    {
        return new DriverViewModel(_driverStatsProviderMock) { Model = driver };
    }
}
