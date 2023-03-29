using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace d02_ex00
{
    internal class Exchanger
    {
        private readonly List<ExchangeRate> _exchangeRates = new();

        public bool ParseRatesFrom(string path)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var from = GetIdentifier(file);
                var lines = GetAllLines(file);
                foreach (var line in lines)
                {
                    var separatorIndex = line.IndexOf(':');
                    var rateValue = double.Parse(line.Substring(separatorIndex + 1));
                    var rate = new ExchangeRate
                    {
                        From = from,
                        To = line.Substring(0, separatorIndex),
                        Rate = rateValue
                    };
                    _exchangeRates.Add(rate);
                }
            }
            return true;
        }

        public IEnumerable<ExchangeSum> ConvertFrom(ExchangeSum sum)
        {
            foreach (var rate in _exchangeRates)
            {
                if (rate.From == sum.Identifier)
                {
                    yield return new ExchangeSum
                    {
                        Amount = Math.Round(sum.Amount * rate.Rate, 2),
                        Identifier = rate.To
                    };
                }
            }
        }

        private string GetIdentifier(string file)
        {
            var ch = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? '\\' : '/';
            var fileName = file.Substring(file.LastIndexOf(ch) + 1);
            return fileName.Substring(0, fileName.IndexOf(".", StringComparison.Ordinal));
        }

        private string[] GetAllLines(string file)
        {
            var stream = File.OpenRead(file);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.Default.GetString(buffer).Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
