namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherData));
                using (System.IO.StringReader reader = new System.IO.StringReader(input))
                {
                    WeatherData weatherData = (WeatherData)serializer.Deserialize(reader);
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
