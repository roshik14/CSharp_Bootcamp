using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d03.Configuration.Sources
{
    internal class YamlSource : IConfigurationSource
    {
        private readonly string _path;
        private readonly int _priority;
        private readonly IDeserializer _deserializer;

        public int Priority => _priority;

        public YamlSource(string path, int priority = 1)
        {
            _path = path;
            _priority = priority;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }


        public Dictionary<string, object>? GetParameters()
        {
            try
            {
                var yaml = File.ReadAllText(_path);
                return _deserializer.Deserialize<Dictionary<string, object>>(yaml);
            }
            catch
            {
                return null;
            }
        }
    }
}
