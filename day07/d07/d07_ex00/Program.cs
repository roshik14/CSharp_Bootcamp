using Microsoft.AspNetCore.Http;
using System.Reflection;

var type = typeof(DefaultHttpContext);

Console.WriteLine($"Type: {type.FullName}");
Console.WriteLine($"Assembly: {type.Assembly.FullName}");
Console.WriteLine($"Based on: {type.BaseType}");

Console.WriteLine();
Console.WriteLine("Fields:");
var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
foreach (var item in type.GetFields(BindingFlags.NonPublic | flags))
{
    Console.WriteLine($"{item.FieldType} {item.Name}");
}

Console.WriteLine();
Console.WriteLine("Properties:");
foreach (var item in type.GetProperties(flags))
{
    Console.WriteLine($"{item.PropertyType.FullName} {item.Name}");
}

Console.WriteLine();
Console.WriteLine("Methods:");
foreach (var item in type.GetMethods(flags))
{
    var parameters = item.GetParameters()
        .Select(x => $"{x.ParameterType.Name} {x.Name}")
        .ToArray();
    Console.WriteLine($"{item.ReturnType.Name} {item.Name} ({string.Join(',', parameters)})");
}