using Formula1Standings.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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

namespace Formula1Standings.UI.Views;
/// <summary>
/// Interaction logic for CircuitsListView.xaml
/// </summary>
public partial class CircuitsListView : UserControl
{
    public CircuitsListView()
    {
        InitializeComponent();
        DataContext = App.Current.ServiceProvider.GetService<CircuitsListViewModel>();
    }
}
