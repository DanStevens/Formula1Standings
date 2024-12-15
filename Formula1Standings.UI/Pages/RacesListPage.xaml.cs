using Formula1Standings.ViewModels;
using System.Windows.Controls;

namespace Formula1Standings.UI.Pages;

public partial class RacesListPage : Page
{
    public RacesListPage()
    {
        InitializeComponent();
    }

    public RacesListPage(RacesListViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
