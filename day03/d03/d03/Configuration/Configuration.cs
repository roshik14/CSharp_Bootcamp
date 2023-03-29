using d03.Configuration.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Configuration
{
    internal class Configuration
    {
        private readonly Dictionary<string, object>? pairs;
        public Configuration(IConfigurationSource source)
        {
            pairs = source.GetParameters();
        }

        public Configuration(IConfigurationSource source1, IConfigurationSource source2)
        {
            var pairs1 = source1.GetParameters();
            var pairs2 = source2.GetParameters();
            if (pairs1 != null && pairs2 != null)
            {
                pairs = source1.Priority < source2.Priority
                    ? Merge(pairs1, pairs2)
                    : Merge(pairs2, pairs1);
            }
        }

        public override string? ToString()
        {
            if (pairs != null)
            {
                var stringBuilder = new StringBuilder("Configuration\n");
                foreach (var pair in pairs)
                {
                    stringBuilder.Append($"{pair.Key}: {pair.Value}\n");
                }
                return stringBuilder.ToString();
            }
            return base.ToString();
        }

        public bool IsValid()
        {
            return pairs != null;
        }

        private Dictionary<string, object> Merge(Dictionary<string, object> first, Dictionary<string, object> second)
        {
            Dictionary<string, object> result = new(first);
            foreach (var kv in second)
            {
                result[kv.Key] = kv.Value;
            }
            return result;
        }
    }
}
