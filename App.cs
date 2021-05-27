using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GettingStartedDotnetConfig
{
    public class App
    {
        private readonly IConfigurationRoot _config;
        private readonly ILogger<App> _logger;

        public App(IConfigurationRoot config, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<App>();
            _config = config;
        }

        public async Task Run()
        {
            List<string> emailAddresses = _config.GetSection("EmailAddresses").Get<List<string>>();
            string test = _config.GetSection("testdotnetenv").Get<string>(); // Only works when configured in environment, restart terminal after saving
            _logger.LogInformation(test);
            foreach (string emailAddress in emailAddresses)
            {
                _logger.LogInformation("Email address: {@EmailAddress}", emailAddress);
            }
        }
    }
}