using Real_time_WeatherMonitoring_and_ReportingService;

var botConfig = ConfigurationManager.GetConfiguration();

if (botConfig == null)
{
    Console.WriteLine("\nBot configurations are unavailable.");
    Environment.Exit(1);
}

var rainBot = new RainBot(botConfig);
var sunBot = new SunBot(botConfig);
var snowBot = new SnowBot(botConfig);

WeatherMonitoringService monitoringService = new WeatherMonitoringService();
monitoringService.AddBot(rainBot);
monitoringService.AddBot(sunBot);
monitoringService.AddBot(snowBot);


while (true)
{
    Console.WriteLine("Enter weather data:");
    string input = Console.ReadLine();
    //TODO: put instance creation in the class
    WeatherDataParserFactory parserFactory = new WeatherDataParserFactory();
    IWeatherDataParser parser = parserFactory.CreateParser(input);

    if (parser == null)
    {
        Console.WriteLine("Unable to determine data format from input.");
    }
    else
    {
        WeatherData weatherData = parser.Parse(input);

        if (weatherData != null)
        {
            Console.WriteLine($"Parsed Weather Data: Location={weatherData.Location}, Temperature={weatherData.Temperature}, Humidity={weatherData.Humidity}");
            
            monitoringService.ProcessWeatherData(weatherData);
        }
    }
}