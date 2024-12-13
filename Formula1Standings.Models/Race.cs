using System.Text.Json.Serialization;

namespace Formula1Standings.Models;

public record class Race
{
    [JsonPropertyName("raceId")]
    public required int Id { get; init; }
    
    [JsonPropertyName("round")]
    public required int Round { get; init; }
    
    [JsonPropertyName("circuitId")]
    public required int CircuitId { get; init; }
    
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("date")]
    public required DateOnly Date { get; init; }
    
    [JsonPropertyName("time")]
    public string? Time { get; init; }
    
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }
    public int Year => Date.Year;
}
