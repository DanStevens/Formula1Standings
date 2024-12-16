using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class RaceViewModel(
    ICircuitRepository circuitRepo) : ObservableObject
{
    private Race? _model;
    private Circuit? _circuit;

    public Race? Model
    {
        get => _model;
        set
        {
            if (SetProperty(ref _model, value))
            {
                Circuit = _model != null ? circuitRepo.Get(_model.CircuitId) : null;
            }
        }
    }
    public Circuit? Circuit
    {
        get => _circuit;
        set => SetProperty(ref _circuit, value);
    }
}
