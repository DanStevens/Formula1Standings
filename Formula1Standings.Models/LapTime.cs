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

    public TimeSpan Time { get; private set; }

    public string TimeFormatted => Time.ToString(Time.TotalHours >= 1 ? @"hh\:mm\:ss\.fff" : @"mm\:ss\.fff");

    [JsonPropertyName("milliseconds")]
    public required double Milliseconds
    {
        get => Time.TotalMilliseconds;
        init => Time = TimeSpan.FromMilliseconds(value);
    }
}