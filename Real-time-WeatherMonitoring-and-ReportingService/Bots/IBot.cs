namespace RealTimeWeatherMonitoringAndReportingService.Bots
{
    public interface IBot
    {
        void Activate(WeatherData weatherData);
    }
}
