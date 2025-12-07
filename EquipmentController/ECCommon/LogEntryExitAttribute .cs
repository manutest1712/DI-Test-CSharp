using MethodDecorator.Fody.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ECCommon
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Module)]
    public class LogEntryExitAttribute : Attribute, IMethodDecorator
    {
        private ILogger _logger;
        private MethodBase _method;

        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;

            // 1. Try to find logger from method arguments
            foreach (var arg in args)
            {
                if (arg is ILogger detectedLogger)
                {
                    _logger = detectedLogger;
                    return; // logger found, we are done
                }
            }

            _logger = (ILogger)instance
                .GetType()
                .GetField("_logger", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(instance);
        }

        public void OnEntry()
        {
            _logger?.LogDebug($"Entering {_method.Name}");
        }

        public void OnExit()
        {
            _logger?.LogDebug($"Exiting {_method.Name}");
        }

        public void OnException(Exception exception)
        {
            _logger?.LogError(exception, $"Exception in {_method.Name}");
        }
    }

}
