using Xunit;
using Moq;
using RealTimeWeatherMonitoringAndReportingService.Bots;
using RealTimeWeatherMonitoringAndReportingService.Models;
using System.Collections.Generic;

namespace RealTimeWeatherMonitoringAndReportingService.Tests
{
    public class WeatherMonitoringServiceTests
    {
        [Fact]
        public void ActivateBotsBasedOnConditions_ShouldCallActivateMethodForAllBots()
        {
            // Arrange
            var weatherData = new WeatherData
            {
             
            };

            var bot1Mock = new Mock<IBot>();
            var bot2Mock = new Mock<IBot>();

            var weatherMonitoringService = new WeatherMonitoringService();
            weatherMonitoringService.AddBot(bot1Mock.Object);
            weatherMonitoringService.AddBot(bot2Mock.Object);

            // Act
            weatherMonitoringService.ActivateBotsBasedOnConditions(weatherData);

            // Assert
            bot1Mock.Verify(bot => bot.Activate(weatherData), Times.Once);
            bot2Mock.Verify(bot => bot.Activate(weatherData), Times.Once);
        }
    }
}
