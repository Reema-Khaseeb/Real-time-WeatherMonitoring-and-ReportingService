namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public interface IWeatherDataParser
    {
        bool TryParse(string input, out WeatherData weatherData);
    }
}
