namespace RealTimeWeatherMonitoringAndReportingService.DataParser
{
    public class WeatherDataParserFactory
    {
        private readonly Dictionary<char, Func<IWeatherDataParser>> parserFactories;

        public WeatherDataParserFactory()
        {
            parserFactories = new Dictionary<char, Func<IWeatherDataParser>>
            {
                { '{', () => new JsonWeatherDataParser() },
                { '<', () => new XmlWeatherDataParser() }
            };
        }
        
        public IWeatherDataParser CreateParser(string input)
        {
            var trimmedInput = input.TrimStart();

            if (string.IsNullOrEmpty(trimmedInput) ||
                !parserFactories.TryGetValue(trimmedInput[0], out var parserFactory))
            {
                Console.WriteLine("Unable to determine data format from input.");
                return null;
            }

            return parserFactory();
        }
    }
}
