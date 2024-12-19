using System;
using System.Windows.Controls;
using Formula1Standings.Services;
using Formula1Standings.ViewModels;

namespace Formula1Standings.UI.Pages
{
    /// <summary>
    /// Interaction logic for DriverDetailsPage.xaml
    /// </summary>
    public partial class DriverDetailsPage : Page, INavigatable
    {
        public DriverDetailsPage()
        {
            InitializeComponent();
        }

        public void OnNavigated(object? arg)
        {
            if (arg is DriverViewModel viewModel)
                DataContext = viewModel;
        }
    }
}
