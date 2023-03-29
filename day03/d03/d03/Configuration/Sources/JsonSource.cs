using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;

namespace d03.Configuration.Sources
{
    internal class JsonSource : IConfigurationSource
    {
        private readonly string _path;

        private readonly int _priority;
        public int Priority  => _priority;

        public JsonSource(string path, int priority = 1)
        {
            _path = path;
            _priority = priority;
        }

        public Dictionary<string, object>? GetParameters()
        {
            try
            {
                using var fs = new FileStream(_path, FileMode.Open);
                return JsonSerializer.Deserialize<Dictionary<string, object>>(fs);
            }
            catch
            {
                return null;
            }
        }
    }
}
