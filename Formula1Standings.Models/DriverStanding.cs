using System.Text.Json.Serialization;

namespace Formula1Standings.Models;

public record class DriverStanding
{
    [JsonPropertyName("driverStandingsId")]
    public required int Id { get; init; }
    
    [JsonPropertyName("raceId")]
    public required int RaceId { get; init; }
    
    [JsonPropertyName("driverId")]
    public required int DriverId { get; init; }
    
    [JsonPropertyName("points")]
    public required decimal Points { get; init; }
    
    [JsonPropertyName("position")]
    public required int Position { get; init; }
    
    [JsonPropertyName("wins")]
    public required int Wins { get; init; }
}
