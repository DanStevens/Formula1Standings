namespace Formula1Standings.Models;

public record class DriverStanding
{
    public required int Id { get; init; }
    public required int RaceId { get; init; }
    public required int DriverId { get; init; }
    public required int Points { get; init; }
    public required int Position { get; init; }
    public required int Wins { get; init; }
}
