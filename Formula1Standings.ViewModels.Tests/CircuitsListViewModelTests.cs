using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels.Tests;

public class CircuitsListViewModelTests
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
    public void Circuits_ShouldBeEmpty_WhenRepositoryIsEmpty()
    {
        var mockRepo = new Mock<ICircuitRepository>();
        mockRepo.Setup(x => x.GetAll()).Returns(Array.Empty<Circuit>());
        var subject = new CircuitsListViewModel(mockRepo.Object, () => new CircuitViewModel());
        subject.Circuits.Should().BeEmpty();
    }

    [Test]
    public void Circuits_ShouldContainOneCircuit_WhenRepositoryContainsOneItem()
    {
        IList<Circuit> allCircuits = [ExampleCircuit];
        var mockRepo = new Mock<ICircuitRepository>();
        mockRepo.Setup(x => x.GetAll()).Returns(allCircuits);
        var subject = new CircuitsListViewModel(mockRepo.Object, () => new CircuitViewModel());
        subject.Circuits.Should().BeEquivalentTo(allCircuits.Select(WrapCircuit));
    }

    private CircuitViewModel WrapCircuit(Circuit circuit)
    {
        var vm = new CircuitViewModel();
        vm.Model = circuit;
        return vm;
    }
}
