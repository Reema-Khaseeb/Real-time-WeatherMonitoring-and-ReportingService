using RealTimeWeatherMonitoringAndReportingService;
using RealTimeWeatherMonitoringAndReportingService.DataParser;
using RealTimeWeatherMonitoringAndReportingService.Bots;

var botConfig = ConfigurationManager.GetConfiguration();

if (botConfig == null)
{
    Console.WriteLine("\nBot configurations are unavailable.");
    Environment.Exit(1);
}

var rainBot = new RainBot(botConfig.RainBot);
var sunBot = new SunBot(botConfig.SunBot);
var snowBot = new SnowBot(botConfig.SnowBot);

var monitoringService = new WeatherMonitoringService();
monitoringService.AddBot(rainBot);
monitoringService.AddBot(sunBot);
monitoringService.AddBot(snowBot);


while (true)
{
    Console.WriteLine("\n\nEnter weather data:");
    var input = Console.ReadLine();
    //TODO: put instance creation in the class
    var parserFactory = new WeatherDataParserFactory();
    var parser = parserFactory.CreateParser(input);

    if (parser == null)
    {
        Console.WriteLine("Unable to determine data format from input.");
    }
    else
    {
        var weatherData = parser.Parse(input);

        if (weatherData != null)
        {
            Console.WriteLine(@$"Parsed Weather Data: 
Location={weatherData.Location}, 
Temperature={weatherData.Temperature}, 
Humidity={weatherData.Humidity}");
            Console.WriteLine();

            monitoringService.ActivateBotsBasedOnConditions(weatherData);
        }
    }
}