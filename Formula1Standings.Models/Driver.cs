namespace Formula1Standings.Models;

public record class Driver
{
    public required int Id { get; init; }
    public required string Reference { get; init; }
    public required string Number { get; init; }
    public required string Code { get; init; }
    public required string Forename { get; init; }
    public required string Surname { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Nationality { get; init; }
    public required Uri Url { get; init; }
}
