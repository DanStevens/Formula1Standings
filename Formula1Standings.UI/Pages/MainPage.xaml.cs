using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Formula1Standings.Services;

namespace Formula1Standings.UI.Pages;

public partial class MainPage : Page
{
    private readonly INavigationService? _navigationService;

    public MainPage()
    {
        InitializeComponent();
        DataContext = this;
    }

    public MainPage(INavigationService navigationService) : this()
    {
        _navigationService = navigationService;
        NavigateCommand = new RelayCommand<string>(Navigate);
    }

    public ICommand? NavigateCommand { get; }

    public void Navigate(string? key)
    {
        if (key != null)
            _navigationService?.Navigate(key);
    }
}
