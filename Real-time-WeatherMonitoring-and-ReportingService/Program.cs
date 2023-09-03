using Real_time_WeatherMonitoring_and_ReportingService;

var botConfig = ConfigurationManager.GetConfiguration("botConfig.json");

var rainBot = new RainBot(botConfig);
var sunBot = new SunBot(botConfig);
var snowBot = new SnowBot(botConfig);

WeatherMonitoringService monitoringService = new WeatherMonitoringService();
monitoringService.AddBot(rainBot);
monitoringService.AddBot(sunBot);
monitoringService.AddBot(snowBot);
