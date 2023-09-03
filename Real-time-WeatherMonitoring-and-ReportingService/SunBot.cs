namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class SunBot : IBot
    {
        private BotConfigurations _config;

        public SunBot(BotConfigurations config)
        {
            _config = config;
        }

        public void Activate(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Temperature > _config.TemperatureThreshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: {_config.Message}");
            }
        }
    }
}
