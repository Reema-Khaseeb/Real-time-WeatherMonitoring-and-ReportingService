using FluentAssertions;
using RealTimeWeatherMonitoringAndReportingService.DataParser;

namespace RealTimeWeatherMonitoringAndReportingService.Tests
{

    public class WeatherDataParserTests
    {
        private readonly ConsoleOutputCapture consoleOutputCapture;

        public WeatherDataParserTests()
        {
            // Initialize the ConsoleOutputCapture to capture console output
            consoleOutputCapture = new ConsoleOutputCapture();
        }

        [Fact]
        public void TryParse_ShouldParse_WhenValidJsonInput()
        {
            // Arrange
            var jsonParser = new JsonWeatherDataParser();
            var jsonInput = "{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}";

            // Act
            var result = jsonParser.TryParse(jsonInput, out var weatherData);

            // Assert
            result.Should().BeTrue();
            weatherData.Should().NotBeNull();
            weatherData.Location.Should().Be("City Name");
            weatherData.Temperature.Should().Be(32);
            weatherData.Humidity.Should().Be(40);
        }

        [Fact]
        public void TryParse_ShouldParse_WhenValidXmlInput()
        {
            // Arrange
            var xmlInput = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
            var parser = new XmlWeatherDataParser();

            // Act
            var result = parser.TryParse(xmlInput, out var weatherData);

            // Assert
            result.Should().BeTrue();
            weatherData.Should().NotBeNull();
            weatherData.Location.Should().Be("City Name");
            weatherData.Temperature.Should().Be(32);
            weatherData.Humidity.Should().Be(40);
        }

        [Fact]
        public void TryParse_ShouldNotParse_WhenInvalidJsonInput()
        {
            // Arrange
            var invalidJsonInput = "Invalid JSON input";
            var parser = new JsonWeatherDataParser();

            // Act
            var result = parser.TryParse(invalidJsonInput, out var weatherData);
            var consoleOutput = consoleOutputCapture.Capture(() => parser.TryParse(
                invalidJsonInput, out var weatherData));
            // Assert
            result.Should().BeFalse();
            weatherData.Should().BeNull();
            consoleOutput.Should().Contain("Error parsing JSON weather data");
        }

        [Fact]
        public void TryParse_ShouldNotParse_WhenInvalidXmlInput()
        {
            // Arrange
            var invalidXmlInput = "Invalid XML input";
            var parser = new XmlWeatherDataParser();

            // Act
            var result = parser.TryParse(invalidXmlInput, out var weatherData);
            var consoleOutput = consoleOutputCapture.Capture(() => parser.TryParse(
                invalidXmlInput, out var weatherData));
            // Assert
            result.Should().BeFalse();
            weatherData.Should().BeNull();
            consoleOutput.Should().Contain("Error parsing XML weather data");
        }

        public void Dispose()
        {
            consoleOutputCapture.Dispose();
        }
    }
    
}

