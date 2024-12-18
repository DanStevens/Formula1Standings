﻿using Formula1Standings.Models;

namespace Formula1Standings.ServiceImplementations.Tests;

public class DriverStandingInMemoryRepositoryTests
{
    [Test]
    public void CreateDefaultInstance()
    {
        var subject = new DriverStandingInMemoryRepository();
        subject.Should().NotBeNull();
        subject.GetAll().Should().BeEmpty();
    }

    [Test]
    public void GetAll_ShouldReturnListOfStandings_WhenGivenPathToDriverStandingsJson()
    {
        var subject = CreateTestSubject();

        var allStandings = subject.GetAll();

        using var _ = new AssertionScope();
        allStandings.Should().HaveCount(34364);
        allStandings.First().Should().Be(new DriverStanding()
        {
            Id = 1,
            RaceId = 18,
            DriverId = 1,
            Points = 10,
            Position = 1,
            Wins = 1,
        });
        allStandings.Last().Should().Be(new DriverStanding()
        {
            Id = 72577,
            RaceId = 1121,
            DriverId = 858,
            Points = 0,
            Position = 20,
            Wins = 0,
        });
    }

    [Test]
    public void GetByDriver_ShouldReturnAllStandingsForGivenDriver()
    {
        var subject = CreateTestSubject();
        var standings = subject.GetByDriver(1);

        using var _ = new AssertionScope();
        standings.Should().HaveCount(333);
        standings.First().Should().Be(new DriverStanding()
        {
            Id = 1,
            RaceId = 18,
            DriverId = 1,
            Points = 10,
            Position = 1,
            Wins = 1,
        });
        standings.Last().Should().Be(new DriverStanding()
        {
            Id = 72564,
            RaceId = 1121,
            DriverId = 1,
            Points = 6,
            Position = 7,
            Wins = 0,
        });
    }

    private static DriverStandingInMemoryRepository CreateTestSubject()
    {
        return new DriverStandingInMemoryRepository(@"Data\driver_standings.json");
    }
}
