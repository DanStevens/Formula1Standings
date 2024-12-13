namespace Formula1Standings.Models;

public record class Race
{
    public required int Id { get; init; }
    public required int Round { get; init; }
    public required int CircuitId { get; init; }
    public required string Name { get; init; }
    public required DateOnly Date { get; init; }
    public TimeOnly? Time { get; init; }
    public required Uri Url { get; init; }
    public int Year => Date.Year;
}
