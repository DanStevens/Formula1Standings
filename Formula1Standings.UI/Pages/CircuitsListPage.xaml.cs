﻿using Formula1Standings.ViewModels;
using System.Windows.Controls;

namespace Formula1Standings.UI.Pages;

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
