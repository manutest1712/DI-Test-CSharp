using System;
using System.Collections.Generic;
using System.Text;

namespace ECInterfaces.Modules
{
    public interface IModule
    {
        string Name { get; }
        void Init();
    }
}
