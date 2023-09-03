using Newtonsoft.Json;

namespace Real_time_WeatherMonitoring_and_ReportingService
{
    public class ConfigurationManager
    {
        private static BotConfigurations _configurations;
        private static readonly string ConfigFilePath = @"C:\\Users\\DELL\\Documents\\GitHub\\Real-time-WeatherMonitoring-and-ReportingService\\Real-time-WeatherMonitoring-and-ReportingService\\botConfig.json";

        public static BotConfigurations GetConfiguration()
        {
            // Read the configuration file and deserialize it if not already loaded
            _configurations ??= ReadBotConfigurations(ConfigFilePath);

            return _configurations;
        }

        private static BotConfigurations ReadBotConfigurations(string configFilePath)
        {
            try
            {
                string json = File.ReadAllText(configFilePath);
                BotConfigurations configurations = JsonConvert.DeserializeObject<BotConfigurations>(json);

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
