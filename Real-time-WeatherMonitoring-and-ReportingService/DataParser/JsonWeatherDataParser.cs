namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                var weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(input);
                Console.WriteLine(weatherData); 
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
