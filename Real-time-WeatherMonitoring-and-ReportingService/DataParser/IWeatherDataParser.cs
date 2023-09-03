namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string input);
    }
}
