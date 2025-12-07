using System;
using System.Collections.Generic;
using System.Text;

namespace ECInterfaces.Devices
{
    public interface ILoadPortDevice : IDevice
    {
        void Dock();
    }
}
