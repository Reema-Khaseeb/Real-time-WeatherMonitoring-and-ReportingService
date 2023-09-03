using Real_time_WeatherMonitoring_and_ReportingService;

var botConfig = ConfigurationManager.GetConfiguration("botConfig.json");

var rainBot = new RainBot(botConfig);
var sunBot = new SunBot(botConfig);
var snowBot = new SnowBot(botConfig);
