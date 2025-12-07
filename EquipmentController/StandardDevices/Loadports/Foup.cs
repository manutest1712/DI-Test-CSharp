using ECInterfaces.Devices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace StandardDevices.Loadports
{
    public class Foup : ILoadPortDevice
    {
        readonly ILogger<Foup> _logger;
        public Foup(IServiceProvider serviceProvider,
                                   ILogger<Foup> logger) {
            _logger = logger;
            _logger.LogInformation("Inside constructor");
        }
        public string Name => "Manu";

        public void Dock()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
