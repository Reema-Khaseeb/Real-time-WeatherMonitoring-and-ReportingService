using RealTimeWeatherMonitoringAndReportingService.Interfaces;
using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService.Services
{
    public class WeatherMonitoringService
    {
        private List<IBot> _bots = new List<IBot>();

        public void AddBot(IBot bot)
        {
            _bots.Add(bot);
        }

        public void ActivateBotsBasedOnConditions(WeatherData weatherData)
        {
            foreach (var bot in _bots)
            {
                bot.Activate(weatherData);
            }
        }
    }
}
