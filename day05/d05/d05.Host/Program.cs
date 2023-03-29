using d05.Nasa;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace d05.Host;

internal static class Program
{
    static async Task Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

        if (args.Length < 1 || !int.TryParse(args[0], out var count))
        {
            Console.WriteLine("Input error.");
            return;
        }

        var config = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json").Build();
        var apiKey = config.GetSection("ApiKey").Value;

        var apod = new ApodClient(apiKey);
        var result = await apod.GetAsync(count);
        if (result.Length == 0)
        {
            Console.WriteLine($"GET \"{apod.RequestUrl}\" returned {apod.StatusCode}");
            Console.WriteLine(apod.ErrorContent);
        }
        else
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
