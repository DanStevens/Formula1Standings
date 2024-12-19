namespace Formula1Standings.Services;

public interface INavigationService
{
    public bool Navigate(string key, object? arg = null);
}