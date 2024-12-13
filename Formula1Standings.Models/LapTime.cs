using System.Text.Json.Serialization;

namespace Formula1Standings.Models;

public record class LapTime
{
    [JsonPropertyName("raceId")]
    public required int RaceId { get; init; }
    
    [JsonPropertyName("driverId")]
    public required int DriverId { get; init; }
    
    [JsonPropertyName("lap")]
    public required int Lap { get; init; }
    
    [JsonPropertyName("position")]
    public required int Position { get; init; }

    [JsonPropertyName("time")]
    public required string Time { get; init; }

    [JsonPropertyName("milliseconds")]
    public required int Milliseconds { get; init; }
}