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
            if (string.IsNullOrEmpty(trimmedInput))
            {
                Console.WriteLine("Input is empty or contains only whitespace.");
                return null;
            }

            if (parserFactories.TryGetValue(trimmedInput[0], out var parserFactory))
            {
                return parserFactory();
            }

            Console.WriteLine("Unable to determine data format from input.");
            return null;
        }
    }
}
