using System.Text.Json;

namespace Formula1Standings.Models.Tests
{
    public class JsonParsingTests
    {
        [Test]
        public void ParseExampleCircuit()
        {
            string json = """
                {
                  "circuitId": 1,
                  "circuitRef": "example",
                  "name": "Example Circuit",
                  "location": "Example City",
                  "country": "Example Country",
                  "lat": 1.0,
                  "lng": 1.0,
                  "alt": 1,
                  "url": "http://example.com/circuits/example"
                }
                """;

            var expected = new Circuit()
            {
                Id = 1,
                Reference = "example",
                Name = "Example Circuit",
                City = "Example City",
                Country = "Example Country",
                Latitude = 1d,
                Longitute = 1d,
                Altitude = 1,
                Url = new Uri("http://example.com/circuits/example")
            };

            var parseResult = JsonSerializer.Deserialize<Circuit>(json);
            parseResult.Should().Be(expected);
        }

        [Test]
        public void ParseExampleDriver()
        {
            string json = """
                {
                  "driverId": 1,
                  "driverRef": "example",
                  "number": "1",
                  "code": "EXA",
                  "forename": "John",
                  "surname": "Smith",
                  "dob": "1985-01-01",
                  "nationality": "British",
                  "url": "http://example.com/drivers/John_Smith"
                }
                """;

            var expected = new Driver()
            {
                Id = 1,
                Reference = "example",
                Number = "1",
                Code = "EXA",
                Forename = "John",
                Surname = "Smith",
                DateOfBirth = new DateOnly(1985, 1, 1),
                Nationality = "British",
                Url = new Uri("http://example.com/drivers/John_Smith")
            };

            var parseResult = JsonSerializer.Deserialize<Driver>(json);
            parseResult.Should().Be(expected);
        }

        [Test]
        public void ParseExampleDriverStanding()
        {
            var json = """
                {
                  "driverStandingsId": 1,
                  "raceId": 1,
                  "driverId": 1,
                  "points": 10.5,
                  "position": 1,
                  "positionText": 1,
                  "wins": 1
                }
                """;

            var expected = new DriverStanding()
            {
                Id = 1,
                DriverId = 1,
                RaceId = 1,
                Points = 10.5M,
                Position = 1,
                Wins = 1,
            };

            var parseResult = JsonSerializer.Deserialize<DriverStanding>(json);
            parseResult.Should().Be(expected);
        }

        [Test]
        public void ParseExampleLapTime()
        {
            string json = """
                {
                  "raceId": 1,
                  "driverId": 1,
                  "lap": 1,
                  "position": 1,
                  "time": "1:0.0",
                  "milliseconds": 60000
                }
                """;

            var expected = new LapTime()
            {
                RaceId = 1,
                DriverId = 1,
                Lap = 1,
                Position = 1,
                Milliseconds = 60_000,
            };

            var parseResult = JsonSerializer.Deserialize<LapTime>(json);
            parseResult.Should().Be(expected);
        }

        [Test]
        public void ParseExampleLapTimeWithExponentInMilliseconds()
        {
            string json = """
                {
                  "raceId": 846,
                  "driverId": 20,
                  "lap": 72,
                  "position": 1,
                  "time": "21:53.041",
                  "milliseconds": 1.313041E+6
                }
                """;

            var expected = new LapTime()
            {
                RaceId = 846,
                DriverId = 20,
                Lap = 72,
                Position = 1,
                Milliseconds = 1.313041E+6,
            };

            var parseResult = JsonSerializer.Deserialize<LapTime>(json);
            parseResult.Should().Be(expected);
        }

        [Test]
        public void ParseExampleRace()
        {
            string json = """
                {
                  "raceId": 1,
                  "year": 2000,
                  "round": 1,
                  "circuitId": 1,
                  "name": "Example Race",
                  "date": "2000-01-01",
                  "time": "00:00:00",
                  "url": "http://example.com/races/2000_Example"
                }
                """;

            var expected = new Race()
            {
                Id = 1,
                Round = 1,
                CircuitId = 1,
                Name = "Example Race",
                Date = new DateOnly(2000, 1, 1),
                Time = "00:00:00",
                Url = new Uri("http://example.com/races/2000_Example")
            };

            var parseResult = JsonSerializer.Deserialize<Race>(json);
            parseResult.Should().Be(expected);
        }
    }
}
