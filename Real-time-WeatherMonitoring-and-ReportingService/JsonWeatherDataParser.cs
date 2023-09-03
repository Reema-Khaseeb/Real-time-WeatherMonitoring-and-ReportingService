namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                WeatherData weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(input);
                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON weather data: {ex.Message}");
                return null;
            }
        }
    }
}
