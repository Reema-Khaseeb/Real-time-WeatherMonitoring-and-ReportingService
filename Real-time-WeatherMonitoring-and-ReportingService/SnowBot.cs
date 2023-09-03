namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class SnowBot : IBot
    {
        private BotConfigurations _config;

        public SnowBot(BotConfigurations config)
        {
            _config = config;
        }

        public void Activate(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Temperature < _config.TemperatureThreshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: {_config.Message}");
            }
        }
    }
}
