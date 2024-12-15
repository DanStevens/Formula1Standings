namespace Formula1Standings.UI.Pages;

public class NavigationEventArgs(object? key) : EventArgs
{
    public object? Key { get; set; } = key;
}
