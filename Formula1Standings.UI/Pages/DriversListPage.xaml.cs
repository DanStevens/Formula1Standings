using Formula1Standings.ViewModels;
using System.Windows.Controls;

namespace Formula1Standings.UI.Pages;

public partial class DriversListPage : Page
{
    public DriversListPage()
    {
        InitializeComponent();
    }

    public DriversListPage(DriversListViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
