namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class WeatherDataParserFactory
    {
        public IWeatherDataParser CreateParser(string input)
        {
            // Determine the format based on the input
            if (input.TrimStart().StartsWith("{"))
            {
                return new JsonWeatherDataParser();
            }
            else if (input.TrimStart().StartsWith("<"))
            {
                return new XmlWeatherDataParser();
            }
            else
            {
                Console.WriteLine("Unable to determine data format from input.");
                return null;
            }
        }
    }
}
