using RealTimeWeatherMonitoringAndReportingService.Bots;
using RealTimeWeatherMonitoringAndReportingService.DataParser;

namespace RealTimeWeatherMonitoringAndReportingService.Utilities
{
    public class WeatherDataProcessingApp
    {
        public static WeatherMonitoringService InitializeMonitoringService(BotsTypes botConfig)
        {
            var monitoringService = new WeatherMonitoringService();
            monitoringService.AddBot(new RainBot(botConfig.RainBot));
            monitoringService.AddBot(new SunBot(botConfig.SunBot));
            monitoringService.AddBot(new SnowBot(botConfig.SnowBot));
            return monitoringService;
        }

        public static void PrintActivatedBots(WeatherMonitoringService monitoringService, string input)
        {
            var parser = CreateWeatherDataParser(input);
            var weatherData = ParseWeatherData(parser, input);

            if (weatherData != null)
            {
                monitoringService.ActivateBotsBasedOnConditions(weatherData);
            }
        }

        public static WeatherData ParseWeatherData(IWeatherDataParser parser, string input)
        {
            return parser.TryParse(input, out var weatherData) ? weatherData : null;
        }


        private static IWeatherDataParser CreateWeatherDataParser(string input)
        {
            var parserFactory = new WeatherDataParserFactory();
            return parserFactory.CreateParser(input);
        }
    }
}
