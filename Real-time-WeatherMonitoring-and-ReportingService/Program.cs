using RealTimeWeatherMonitoringAndReportingService;
using RealTimeWeatherMonitoringAndReportingService.Utilities;

var botConfig = ConfigurationManager.GetConfiguration();

if (botConfig == null)
{
    Console.WriteLine("\nBot configurations are unavailable.");
    Environment.Exit(1);
}

var monitoringService = WeatherDataProcessingApp.InitializeMonitoringService(botConfig);

while (true)
{
    Console.WriteLine("\n\nEnter weather data:");
    var input = Console.ReadLine();

    WeatherDataProcessingApp.PrintActivatedBots(monitoringService, input);
}
