using Newtonsoft.Json;
using RealTimeWeatherMonitoringAndReportingService.Models;

namespace RealTimeWeatherMonitoringAndReportingService
{
    public class ConfigurationManager
    {
        private static BotsTypes _configurations;
        private static readonly string ConfigFilePath = @"C:\\Users\\DELL\\Documents\\GitHub\\Real-time-WeatherMonitoring-and-ReportingService\\Real-time-WeatherMonitoring-and-ReportingService\\botConfig.json";

        public static BotsTypes GetConfiguration()
        {
            // Read the configuration file and deserialize it if not already loaded
            _configurations ??= ReadBotConfigurations(ConfigFilePath);

            return _configurations;
        }

        private static BotsTypes ReadBotConfigurations(string configFilePath)
        {
            try
            {
                var json = File.ReadAllText(configFilePath);
                var configurations = JsonConvert.DeserializeObject<BotsTypes>(json);

                return configurations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading configuration file: {ex.Message}");
                return null;
            }
        }
    }
}
