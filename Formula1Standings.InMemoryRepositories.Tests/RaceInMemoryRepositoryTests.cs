﻿using Formula1Standings.Models;

namespace Formula1Standings.InMemoryRepositories.Tests;

public class RaceInMemoryRepositoryTests
{
    private Race Race1 = new()
    {
        Id = 1,
        Round = 1,
        CircuitId = 1,
        Name = "Australian Grand Prix",
        Date = new DateOnly(2009, 03, 29),
        Time = "06:00:00",
        Url = new Uri("http://en.wikipedia.org/wiki/2009_Australian_Grand_Prix")
    };

    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new RaceInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfRaces_WhenGivenPathToRacesJson()
    {
        var subject = new RaceInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\races.json");
        
        var allRaces = subject.GetAll();

        using var _ = new AssertionScope();
        allRaces.Should().HaveCount(1125);
        allRaces.First().Should().Be(Race1);
        allRaces.Last().Should().Be(new Race()
        {
            Id = 1144,
            Round = 24,
            CircuitId = 24,
            Name = "Abu Dhabi Grand Prix",
            Date = new DateOnly(2024, 12, 08),
            Time = "\\N",
            Url = new Uri("https://en.wikipedia.org/wiki/2024_Abu_Dhabi_Grand_Prix")
        });
    }

    [Test]
    public void Get_ShouldReturnRaceWithGivenId()
    {
        var subject = new RaceInMemoryRepository();
        subject.LoadFromJsonFile(@"Data\races.json");
        var race = subject.Get(1);
        race.Should().Be(Race1);
    }
}