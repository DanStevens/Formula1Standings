using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class CircuitsListViewModel : ObservableObject
{
    public CircuitsListViewModel(
        ICircuitRepository repo,
        Func<CircuitViewModel> circuitViewModelFactory)
    {
        Circuits = repo.GetAll().Select(Wrap).ToArray();

        CircuitViewModel Wrap(Circuit circuit)
        {
            var vm = circuitViewModelFactory();
            vm.Model = circuit;
            return vm;
        }
    }

    public IList<CircuitViewModel> Circuits { get; }
}
