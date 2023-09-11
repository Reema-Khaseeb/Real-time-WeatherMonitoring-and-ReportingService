using FluentAssertions;
using RealTimeWeatherMonitoringAndReportingService.Bots;
using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService.Tests
{
    public class ActivateBotTests : IDisposable
    {
        private readonly ConsoleOutputCapture consoleOutputCapture;

        public ActivateBotTests()
        {
            consoleOutputCapture = new ConsoleOutputCapture();
        }
        
        [Fact]
        public void Activate_ShouldActivateAndPrintMessageRainBot_WhenEnabledIsTrueAndHumidityExceedsThreshold()
        {
            // Arrange
            var configRainBot = new BotConfigurations
            {
                Enabled = true,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(configRainBot);
            var weatherData = new WeatherData
            {
                Humidity = 75
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => rainBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().Contain("RainBot activated!");
            consoleOutput.Should().Contain("RainBot: It looks like it's about to pour down!");
            configRainBot.Enabled.Should().BeTrue();
            weatherData.Humidity.Should().BeGreaterThan(configRainBot.HumidityThreshold);
        }

        [Theory]
        [InlineData(true, 65)]
        [InlineData(false, 65)]
        [InlineData(true, 75)]
        [InlineData(false, 75)]
        public void Activate_ShouldNotActivateNorPrintMessageRainBot_WhenHumidityLessOrEqualToThreshold(bool isEnabled, double humidity)
        {
            {
                // Arrange
                var configRainBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    HumidityThreshold = 70,
                    Message = "It looks like it's about to pour down!"
                };
                var rainBot = new RainBot(configRainBot);
                var weatherData = new WeatherData
                {
                    Humidity = 65
                };

                // Act
                var consoleOutput = consoleOutputCapture.Capture(() => rainBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Humidity.Should().BeLessOrEqualTo(configRainBot.HumidityThreshold);
            }
        }

        [Theory]
        [InlineData(65)]
        [InlineData(70)]
        [InlineData(75)]
        public void Activate_ShouldNotActivateNorPrintMessageRainBot_WhenEnabledIsFalse(double humidity)
        {
            // Arrange
            var configRainBot = new BotConfigurations
            {
                Enabled = false,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(configRainBot);
            var weatherData = new WeatherData
            {
                Humidity = humidity
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => rainBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configRainBot.Enabled.Should().BeFalse();
        }






        [Fact]
        public void Activate_ShouldActivateAndPrintMessageSunBot_WhenEnabledIsTrueAndTemperatureExceedsThreshold()
        {
            // Arrange
            var configSunBot = new BotConfigurations
            {
                Enabled = true,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(configSunBot);
            var weatherData = new WeatherData
            {
                Temperature = 35
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => sunBot.Activate(weatherData));   

            // Assert
            consoleOutput.Should().Contain("SunBot activated!");
            consoleOutput.Should().Contain("SunBot: Wow, it's a scorcher out there!");
            configSunBot.Enabled.Should().BeTrue();
            weatherData.Temperature.Should().BeGreaterThan(configSunBot.TemperatureThreshold);
        }

        [Theory]
        [InlineData(true, 20)]
        [InlineData(false, 20)]
        [InlineData(true, 30)]
        [InlineData(false, 30)]
        public void Activate_ShouldNotActivateNorPrintMessageSunBot_WhenTemperatureLessOrEqualToThreshold(bool isEnabled, double temperature)
        {
            {
                // Arrange
                var configSunBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    TemperatureThreshold = 30,
                    Message = "Wow, it's a scorcher out there!"
                };
                var sunBot = new SunBot(configSunBot);
                var weatherData = new WeatherData
                {
                    Temperature = temperature
                };

                // Act
                var consoleOutput = consoleOutputCapture.Capture(() => sunBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Temperature.Should().BeLessOrEqualTo(configSunBot.TemperatureThreshold);
            }
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(35)]
        public void Activate_ShouldNotActivateNorPrintMessageSunBot_WhenEnabledIsFalse(double temperature)
        {
            // Arrange
            var configSunBot = new BotConfigurations
            {
                Enabled = false,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(configSunBot);
            var weatherData = new WeatherData
            {
                Temperature = temperature
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => sunBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configSunBot.Enabled.Should().BeFalse();
        }






        [Fact]
        public void Activate_ShouldActivateAndPrintMessageSnowBot_WhenEnabledIsTrueAndTemperatureGreaterOrEqualToThreshold()
        {
            // Arrange
            var configSnowBot = new BotConfigurations
            {
                Enabled = true,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SnowBot(configSnowBot);
            var weatherData = new WeatherData
            {
                Temperature = -5
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => snowBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().Contain("SnowBot activated!");
            consoleOutput.Should().Contain("SnowBot: Brrr, it's getting chilly!");
            configSnowBot.Enabled.Should().BeTrue();
            weatherData.Temperature.Should().BeLessThan(configSnowBot.TemperatureThreshold);
        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(false, 0)]
        [InlineData(true, 30)]
        [InlineData(false, 30)]
        public void Activate_ShouldNotActivateNorPrintMessageSnowBot_WhenTemperatureGreaterOrEqualToThreshold(bool isEnabled, double temperature)
        {
            {
                // Arrange
                var configSnowBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    TemperatureThreshold = 0,
                    Message = "Brrr, it's getting chilly!"
                };
                var snowBot = new SnowBot(configSnowBot);
                var weatherData = new WeatherData
                {
                    Temperature = temperature
                };

                // Act
                var consoleOutput = consoleOutputCapture.Capture(() => snowBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Temperature.Should().BeGreaterOrEqualTo(configSnowBot.TemperatureThreshold);

            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(5)]
        public void Activate_ShouldNotActivateNorPrintMessageSnowBot_WhenEnabledIsFalse(double temperature)
        {
            // Arrange
            var configSnowBot = new BotConfigurations
            {
                Enabled = false,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SunBot(configSnowBot);
            var weatherData = new WeatherData
            {
                Temperature = temperature
            };

            // Act
            var consoleOutput = consoleOutputCapture.Capture(() => snowBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configSnowBot.Enabled.Should().BeFalse();
        }

        public void Dispose()
        {
            consoleOutputCapture.Dispose();
        }
    }
}






/*
using FluentAssertions;
using RealTimeWeatherMonitoringAndReportingService.Bots;

namespace RealTimeWeatherMonitoringAndReportingService.Tests
{
    public class ActivateBotTests : IDisposable
    {
        private readonly StringWriter consoleOutput;

        public ActivateBotTests()
        {
            // Initialize the StringWriter to capture console output
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [Fact]
        public void Activate_ShouldActivateAndPrintMessageRainBot_WhenEnabledIsTrueAndHumidityExceedsThreshold()
        {
            // Arrange
            var configRainBot = new BotConfigurations
            {
                Enabled = true,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(configRainBot);
            var weatherData = new WeatherData
            {
                Humidity = 75
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => rainBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().Contain("RainBot activated!");
            consoleOutput.Should().Contain("RainBot: It looks like it's about to pour down!");
            configRainBot.Enabled.Should().BeTrue();
            weatherData.Humidity.Should().BeGreaterThan(configRainBot.HumidityThreshold);
        }

        [Theory]
        [InlineData(true, 65)]
        [InlineData(false, 65)]
        [InlineData(true, 75)]
        [InlineData(false, 75)]
        public void Activate_ShouldNotActivateNorPrintMessageRainBot_WhenHumidityLessOrEqualToThreshold(bool isEnabled, double humidity)
        {
            {
                // Arrange
                var configRainBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    HumidityThreshold = 70,
                    Message = "It looks like it's about to pour down!"
                };
                var rainBot = new RainBot(configRainBot);
                var weatherData = new WeatherData
                {
                    Humidity = 65
                };

                // Act
                var consoleOutput = CaptureConsoleOutput(() => rainBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Humidity.Should().BeLessOrEqualTo(configRainBot.HumidityThreshold);
            }
        }

        [Theory]
        [InlineData(65)]
        [InlineData(70)]
        [InlineData(75)]
        public void Activate_ShouldNotActivateNorPrintMessageRainBot_WhenEnabledIsFalse(double humidity)
        {
            // Arrange
            var configRainBot = new BotConfigurations
            {
                Enabled = false,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(configRainBot);
            var weatherData = new WeatherData
            {
                Humidity = humidity
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => rainBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configRainBot.Enabled.Should().BeFalse();
        }






        [Fact]
        public void Activate_ShouldActivateAndPrintMessageSunBot_WhenEnabledIsTrueAndTemperatureExceedsThreshold()
        {
            // Arrange
            var configSunBot = new BotConfigurations
            {
                Enabled = true,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(configSunBot);
            var weatherData = new WeatherData
            {
                Temperature = 35
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => sunBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().Contain("SunBot activated!");
            consoleOutput.Should().Contain("SunBot: Wow, it's a scorcher out there!");
            configSunBot.Enabled.Should().BeTrue();
            weatherData.Temperature.Should().BeGreaterThan(configSunBot.TemperatureThreshold);
        }

        [Theory]
        [InlineData(true, 20)]
        [InlineData(false, 20)]
        [InlineData(true, 30)]
        [InlineData(false, 30)]
        public void Activate_ShouldNotActivateNorPrintMessageSunBot_WhenTemperatureLessOrEqualToThreshold(bool isEnabled, double temperature)
        {
            {
                // Arrange
                var configSunBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    TemperatureThreshold = 30,
                    Message = "Wow, it's a scorcher out there!"
                };
                var sunBot = new SunBot(configSunBot);
                var weatherData = new WeatherData
                {
                    Temperature = temperature
                };

                // Act
                var consoleOutput = CaptureConsoleOutput(() => sunBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Temperature.Should().BeLessOrEqualTo(configSunBot.TemperatureThreshold);
            }
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(35)]
        public void Activate_ShouldNotActivateNorPrintMessageSunBot_WhenEnabledIsFalse(double temperature)
        {
            // Arrange
            var configSunBot = new BotConfigurations
            {
                Enabled = false,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(configSunBot);
            var weatherData = new WeatherData
            {
                Temperature = temperature
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => sunBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configSunBot.Enabled.Should().BeFalse();
        }






        [Fact]
        public void Activate_ShouldActivateAndPrintMessageSnowBot_WhenEnabledIsTrueAndTemperatureGreaterOrEqualToThreshold()
        {
            // Arrange
            var configSnowBot = new BotConfigurations
            {
                Enabled = true,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SnowBot(configSnowBot);
            var weatherData = new WeatherData
            {
                Temperature = -5
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => snowBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().Contain("SnowBot activated!");
            consoleOutput.Should().Contain("SnowBot: Brrr, it's getting chilly!");
            configSnowBot.Enabled.Should().BeTrue();
            weatherData.Temperature.Should().BeLessThan(configSnowBot.TemperatureThreshold);
        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(false, 0)]
        [InlineData(true, 30)]
        [InlineData(false, 30)]
        public void Activate_ShouldNotActivateNorPrintMessageSnowBot_WhenTemperatureGreaterOrEqualToThreshold(bool isEnabled, double temperature)
        {
            {
                // Arrange
                var configSnowBot = new BotConfigurations
                {
                    Enabled = isEnabled,
                    TemperatureThreshold = 0,
                    Message = "Brrr, it's getting chilly!"
                };
                var snowBot = new SnowBot(configSnowBot);
                var weatherData = new WeatherData
                {
                    Temperature = temperature
                };

                // Act
                var consoleOutput = CaptureConsoleOutput(() => snowBot.Activate(weatherData));

                // Assert
                consoleOutput.Should().BeEmpty();
                weatherData.Temperature.Should().BeGreaterOrEqualTo(configSnowBot.TemperatureThreshold);

            }
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(5)]
        public void Activate_ShouldNotActivateNorPrintMessageSnowBot_WhenEnabledIsFalse(double temperature)
        {
            // Arrange
            var configSnowBot = new BotConfigurations
            {
                Enabled = false,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SunBot(configSnowBot);
            var weatherData = new WeatherData
            {
                Temperature = temperature
            };

            // Act
            var consoleOutput = CaptureConsoleOutput(() => snowBot.Activate(weatherData));

            // Assert
            consoleOutput.Should().BeEmpty();
            configSnowBot.Enabled.Should().BeFalse();
        }




        // IDisposable implementation to restore console output after tests
        public void Dispose()
        {
            // Clean up and restore the original console output
            consoleOutput.Dispose();
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        private string CaptureConsoleOutput(Action action)
        {
            consoleOutput.GetStringBuilder().Clear(); // Clear any previous output
            action.Invoke();
            return consoleOutput.ToString();
        }
    }
}
*/