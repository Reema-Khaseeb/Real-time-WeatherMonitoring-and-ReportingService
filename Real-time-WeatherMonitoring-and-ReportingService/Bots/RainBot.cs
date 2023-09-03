namespace RealTimeWeatherMonitoringAndReportingService.Bots
{
    public class RainBot : IBot
    {
        private BotConfigurations _config;

        public RainBot(BotConfigurations config)
        {
            _config = config;
        }

        public void Activate(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Humidity > _config.HumidityThreshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: {_config.Message}");
            }
        }
    }
}
