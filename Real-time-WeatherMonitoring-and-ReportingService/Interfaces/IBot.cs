using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService.Interfaces
{
    public interface IBot
    {
        void Activate(WeatherData weatherData);
    }
}
