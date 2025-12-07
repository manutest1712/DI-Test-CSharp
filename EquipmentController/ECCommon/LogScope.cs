using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECCommon
{
    public class LogScope : IDisposable
    {
        private readonly ILogger _logger;
        private readonly string _methodName;

        public LogScope(ILogger logger, string methodName)
        {
            _logger = logger;
            _methodName = methodName;
            _logger.LogInformation($"Entering {_methodName}");
        }

        public void Dispose()
        {
            _logger.LogInformation($"Exiting {_methodName}");
        }
    }
}
