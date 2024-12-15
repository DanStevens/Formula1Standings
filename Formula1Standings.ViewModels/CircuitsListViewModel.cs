﻿using CommunityToolkit.Mvvm.ComponentModel;
using Formula1Standings.DataAccess;
using Formula1Standings.Models;

namespace Formula1Standings.ViewModels;

public class CircuitsListViewModel(
    IRepository<Circuit> repo
) : ObservableObject
{
    public IList<Circuit> Circuits { get; } = repo.GetAll();
}
