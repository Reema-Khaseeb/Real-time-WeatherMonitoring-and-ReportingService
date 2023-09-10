namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string input, out WeatherData weatherData)
        {
            try
            {
                weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(input);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON weather data: {ex.Message}");
                weatherData = null;
                return false;
            }
        }
    }
}
