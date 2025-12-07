using System;
using System.Collections.Generic;
using System.Text;

namespace ECInterfaces.Devices
{
    public interface IDevice
    {
        string Name { get; }
        void Init();
    }
}
