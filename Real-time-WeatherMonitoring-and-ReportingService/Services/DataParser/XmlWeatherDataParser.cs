using RealTimeWeatherMonitoringAndReportingService.Interfaces;
using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService.Services.DataParser
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string input, out WeatherData weatherData)
        {
            try
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(input))
                {
                    weatherData = (WeatherData)serializer.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing XML weather data: {ex.Message}");
                weatherData = null;
                return false;
            }
        }
    }
}
