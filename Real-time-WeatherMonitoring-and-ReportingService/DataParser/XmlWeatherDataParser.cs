namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(input))
                {
                    var weatherData = (WeatherData)serializer.Deserialize(reader);
                    Console.WriteLine(weatherData);
                    return weatherData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing XML weather data: {ex.Message}");
                return null;
            }
        }
    }
}
