using FluentAssertions;
using RealTimeWeatherMonitoringAndReportingService.DataParser;

namespace RealTimeWeatherMonitoringAndReportingService.Tests
{
    public class WeatherDataParserFactoryTests
    {
        [Fact]
        public void CreateParser_ShouldReturnJsonParser_WhenValidInputFormat()
        {
            // Arrange
            var factory = new WeatherDataParserFactory();
            var jsonInput = "{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}";

            // Act
            var parser = factory.CreateParser(jsonInput);

            // Assert
            parser.Should().BeOfType<JsonWeatherDataParser>();
        }

        [Fact]
        public void CreateParser_ShouldReturnXmlParser_WhenValidInputFormat()
        {
            // Arrange
            var factory = new WeatherDataParserFactory();
            var xmlInput = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";

            // Act
            var parser = factory.CreateParser(xmlInput);

            // Assert
            parser.Should().BeOfType<XmlWeatherDataParser>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Invalid input")]
        public void CreateParser_ShouldReturnNullAndWriteErrorMessageToConsole_WhenInvalidInputFormatOrInputIsNullOrEmpty(string input)
        {
            // Arrange
            var factory = new WeatherDataParserFactory();
            var consoleOutputCapture = new ConsoleOutputCapture();

            // Act
            var parser = factory.CreateParser(input);
            var consoleOutput = consoleOutputCapture.Capture(() => factory.CreateParser(input));

            // Assert
            parser.Should().BeNull();
            consoleOutput.Should().Contain("Unable to determine data format from input.");
        }
    }
}
