namespace Formula1Standings.Models;

public record class Circuit
{
    public required int Id { get; init; }
    public required string Reference { get; init; }
    public required string Name { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
    public required double Latitude { get; init; }
    public required double Longitute { get; init; }
    public required int Altitude { get; init; }
    public required Uri Url { get; init; }
}