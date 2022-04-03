using Caliburn.Micro;
using Serilog;
using System;

namespace SELwpf.Helpers
{
    internal class CustomLogger : ILog
    {
        private readonly ILogger logger;

        public CustomLogger()
        {
            logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Seq(@"http://localhost:8081")
                .CreateLogger();
        }


        private string CreateLogMessage(string format, params object[] args)
        {
            return $"[{DateTime.Now.ToString("o")}] {string.Format(format, args)}";
        }
        private string CreateLogMessage(string message)
        {
            return string.Format("[{0}] {1}",
                DateTime.Now.ToString("o"),
                message);
        }

        public void Error(Exception exception)
        {
            logger.Error(CreateLogMessage(exception.ToString()), "ERROR");
        }

        public void Info(string format, params object[] args)
        {
            if (Array.FindIndex(args, t => t.ToString().Contains("Something i dont want to log")) >= 0)
                return;
            logger.Information(args != null ? CreateLogMessage(format, args) : CreateLogMessage(format), "INFO");
        }

        public void Warn(string format, params object[] args)
        {
            logger.Warning(args != null ? CreateLogMessage(format, args) : CreateLogMessage(format), "WARN");
        }

    }
}
