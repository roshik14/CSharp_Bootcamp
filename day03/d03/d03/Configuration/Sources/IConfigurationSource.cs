using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Configuration.Sources
{
    internal interface IConfigurationSource
    {
        int Priority { get; }
        Dictionary<string, object>? GetParameters();

    }
}
