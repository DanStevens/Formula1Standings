using Formula1Standings.ViewModels;
using System.Windows.Controls;

namespace Formula1Standings.UI.Pages;

public partial class LapTimesListPage : Page
{
    public LapTimesListPage()
    {
        InitializeComponent();
    }

    public LapTimesListPage(LapTimesListViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
