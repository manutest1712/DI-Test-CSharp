using MethodDecorator.Fody.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
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
        private static readonly ConcurrentDictionary<Type, FieldInfo> _loggerFieldCache
            = new ConcurrentDictionary<Type, FieldInfo>();

        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;

            if (instance == null)
            {
                // 1. Try to find logger from method arguments
                foreach (var arg in args)
                {
                    if (arg is ILogger detectedLogger)
                    {
                        _logger = detectedLogger;
                        return; // logger found, we are done
                    }
                }
            }
            else
            {
                // ---------------------------------------------------
                // 2. SLOW PATH → Get logger from instance._logger via cached reflection
                // ---------------------------------------------------

                var type = instance.GetType();

                // Fetch cached or reflect once
                var loggerField = _loggerFieldCache.GetOrAdd(type, t =>
                    t.GetField("_logger", BindingFlags.Instance | BindingFlags.NonPublic)
                );

                _logger = loggerField?.GetValue(instance) as ILogger;
            }
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
