using Formula1Standings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Formula1Standings.UI.Pages;
/// <summary>
/// Interaction logic for CircuitsListPage.xaml
/// </summary>
public partial class CircuitsListPage : Page
{
    public CircuitsListPage()
    {
        InitializeComponent();
    }

    public CircuitsListPage(CircuitsListViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
