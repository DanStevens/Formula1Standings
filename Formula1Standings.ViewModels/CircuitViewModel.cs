using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class CircuitViewModel : ObservableObject
{
    private Circuit? _model;

    public Circuit? Model
    {
        get => _model;
        set => SetProperty(ref _model, value);
    }
}
