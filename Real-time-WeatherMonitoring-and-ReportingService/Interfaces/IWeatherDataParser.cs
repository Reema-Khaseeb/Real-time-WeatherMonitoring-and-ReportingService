using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService.Interfaces
{
    public interface IWeatherDataParser
    {
        bool TryParse(string input, out WeatherData weatherData);
    }
}
