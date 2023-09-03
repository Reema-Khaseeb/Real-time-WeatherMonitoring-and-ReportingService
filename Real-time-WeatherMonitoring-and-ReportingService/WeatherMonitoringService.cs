namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class WeatherMonitoringService
    {
        private List<IBot> _bots = new List<IBot>();

        public void AddBot(IBot bot)
        {
            _bots.Add(bot);
        }

        public void ProcessWeatherData(WeatherData weatherData)
        {
            foreach (var bot in _bots)
            {
                bot.Activate(weatherData);
            }
        }
    }

}
