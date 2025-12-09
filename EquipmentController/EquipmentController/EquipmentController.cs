using ECCommon;
using ECInterfaces.Devices;
using ECInterfaces.Modules;
using MethodDecorator.Fody.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace EquipmentController
{
    internal class EquipmentController
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EquipmentController> _logger;

        [LogEntryExit]
        public EquipmentController(IServiceProvider serviceProvider,
                                   ILogger<EquipmentController> logger)
        {

            _serviceProvider = serviceProvider;
            _logger = logger;

            using (new LogScope(_logger, nameof(EquipmentController)))
            {

                _logger.LogInformation("EquipmentController created.");

                var assembly = Assembly.LoadFrom("StandardDevices.dll");

                var deviceType = assembly.GetType("StandardDevices.Loadports.Foup", throwOnError: true);

                // Resolve via DI so dependencies get injected

                var device = (ILoadPortDevice)ActivatorUtilities.CreateInstance(_serviceProvider, deviceType);

                int i = 0;
                ++i;
            }

            Run();
            Run();
        }

        [LogEntryExit]
        public void Run()
        {
            _logger.LogError(
                "Controller {Controller} Method {Method} not implemented.",
                nameof(EquipmentController),
                nameof(Run));
        }
    }
}
