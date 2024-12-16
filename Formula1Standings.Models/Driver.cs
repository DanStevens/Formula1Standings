using System.Text.Json.Serialization;

namespace Formula1Standings.Models;

public record class Driver
{
    [JsonPropertyName("driverId")]
    public required int Id { get; init; }

    [JsonPropertyName("driverRef")]
    public required string Reference { get; init; }
    
    [JsonPropertyName("number")]
    public string? Number { get; init; }
    
    [JsonPropertyName("code")]
    public string? Code { get; init; }
    
    [JsonPropertyName("forename")]
    public required string Forename { get; init; }
    
    [JsonPropertyName("surname")]
    public required string Surname { get; init; }
    
    [JsonPropertyName("dob")]
    public required DateOnly DateOfBirth { get; init; }
    
    [JsonPropertyName("nationality")]
    public required string Nationality { get; init; }
    
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }

    public string FullName => $"{Forename} {Surname}";
}
