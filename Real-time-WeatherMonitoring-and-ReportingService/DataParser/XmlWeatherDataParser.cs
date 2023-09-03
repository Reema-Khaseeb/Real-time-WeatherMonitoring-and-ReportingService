namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherData));
                using (StringReader reader = new StringReader(input))
                {
                    WeatherData weatherData = (WeatherData)serializer.Deserialize(reader);
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
