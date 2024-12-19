using System.Windows.Controls;
using Formula1Standings.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Formula1Standings.UI.Services;

public class NavigationService : INavigationService
{
    public const string DestResolverKey = nameof(NavigationService) + "DestResolver";

    private readonly Frame _frame;
    private readonly Func<string, object?, object?> _keyResolver;

    public NavigationService(
        [FromKeyedServices(App.RootFrame)] Frame frame,
        [FromKeyedServices(DestResolverKey)] Func<string, object?, object?> destResolver)
    {
        _frame = frame;
        _keyResolver = destResolver;
    }

    public bool Navigate(string key, object? arg = null)
    {
        var content = _keyResolver(key, arg);
        return _frame.Navigate(content, arg);
    }
}
