namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string input);
    }
}
