namespace Formula1Standings.Models;

public record class LapTime
{
    public required int RaceId { get; init; }
    public required int DriverId { get; init; }
    public required int Lap { get; init; }
    public required int Position { get; init; }
    public required TimeSpan Time { get; init; }
    public required int Milliseconds { get; init; }
}