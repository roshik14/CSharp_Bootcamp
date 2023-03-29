using d03.Configuration;
using d03.Configuration.Sources;

if (args.Length != 4 || !int.TryParse(args[1], out var p1) || !int.TryParse(args[3], out var p2))
{
    Console.WriteLine("Something went wrong. Check your input and retry.");
    return;
}

var configuration = new Configuration(new JsonSource(args[0], p1), new YamlSource(args[2], p2));
if (configuration.IsValid())
{
    Console.WriteLine(configuration);
} else
{
    Console.WriteLine("Invalid data. Check your input and try again.");
}

//var jsonConfiguration = new Configuration(new JsonSource(args[0]));
//Console.WriteLine(jsonConfiguration);

//var yamlConfiguration = new Configuration(new YamlSource(args[0]));
//if (yamlConfiguration.IsValid())
//{
//    Console.WriteLine(yamlConfiguration);
//}
//else
//{
//    Console.WriteLine("Invalid data. Check your input and try again.");
//}


