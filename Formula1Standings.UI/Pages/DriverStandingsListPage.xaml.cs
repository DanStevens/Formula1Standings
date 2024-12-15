using Formula1Standings.ViewModels;
using System.Windows.Controls;

namespace Formula1Standings.UI.Pages;

public partial class DriverStandingsListPage : Page
{
    public DriverStandingsListPage()
    {
        InitializeComponent();
    }

    public DriverStandingsListPage(DriverStandingsListViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
