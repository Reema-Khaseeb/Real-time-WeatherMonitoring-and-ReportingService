namespace RealTimeWeatherMonitoringAndReportingService.Tests
{
    public class ConsoleOutputCapture : IDisposable
    {
        private readonly TextWriter originalConsoleOut;
        private readonly StringWriter consoleOutput;

        public ConsoleOutputCapture()
        {
            originalConsoleOut = Console.Out;
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        public string Capture(Action action)
        {
            consoleOutput.GetStringBuilder().Clear();
            action.Invoke();
            return consoleOutput.ToString();
        }

        public void Dispose()
        {
            consoleOutput.Dispose();
            Console.SetOut(originalConsoleOut);
        }

        public string GetCapturedOutput()
        {
            return consoleOutput.ToString();
        }
    }
}
