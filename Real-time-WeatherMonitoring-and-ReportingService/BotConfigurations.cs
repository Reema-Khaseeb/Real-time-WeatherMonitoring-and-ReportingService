﻿namespace RealTimeWeatherMonitoringAndReportingService
{
    public class BotConfigurations
    {
        public bool Enabled { get; set; }
        public double TemperatureThreshold { get; set; }
        public double HumidityThreshold { get; set; }
        public string Message { get; set; }
    }
}
