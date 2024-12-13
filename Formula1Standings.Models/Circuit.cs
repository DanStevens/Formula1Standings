using System.Text.Json.Serialization;

namespace Formula1Standings.Models;

public record class Circuit
{
    [JsonPropertyName("circuitId")]
    public required int Id { get; init; }

    [JsonPropertyName("circuitRef")]
    public required string Reference { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("location")]
    public required string City { get; init; }
    
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    [JsonPropertyName("lat")]
    public required double Latitude { get; init; }
    
    [JsonPropertyName("lng")]
    public required double Longitute { get; init; }

    [JsonPropertyName("alt")]
    public required int Altitude { get; init; }
    
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }
}