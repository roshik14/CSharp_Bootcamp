var names = File.ReadAllLines("us_names.txt");

Console.WriteLine("Enter name:");
var input = Console.ReadLine()?.Trim();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Something went wrong. Check your input and retry.");
    return;
}

var isFound = false;

foreach (var name in names)
{
    var distance = GetLevensteinDistance(input, name);
    if (distance < 2)
    {
        if (name == input)
        {
            Console.WriteLine($"Hello, {{{name}}}!");
            isFound = true;
            break;
        }
        Console.WriteLine($"Did you mean \"{{{name}}}\"? Y/N");
        var answer = Console.ReadLine()?.ToLower();
        if (string.IsNullOrEmpty(answer))
        {
            Console.WriteLine("Something went wrong. Check your input and retry.");
            return;
        }
        if (answer == "y")
        {
            Console.WriteLine($"Hello, {{{name}}}!");
            isFound = true;
            break;
        }
    }
}

if (!isFound)
{
    Console.WriteLine("Your name was not found.");
}

int GetLevensteinDistance(string first, string second)
{
    var opt = new int[first.Length + 1, second.Length + 1];
    for (var i = 0; i < first.Length; i++)
    {
        opt[i, 0] = i;
    }
    for (var i = 0; i < second.Length; i++)
    {
        opt[0, i] = i;
    }
    for (var i = 1; i <= first.Length; i++)
    {
        for (var j = 1; j <= second.Length; j++)
        {
            opt[i, j] = first[i - 1] == second[j - 1]
                ? opt[i - 1, j - 1]
                : Min(0 + opt[i - 1, j], 1 + opt[i - 1, j - 1], 1 + opt[i, j - 1]);
        }
    }
    return opt[first.Length, second.Length];
}

int Min(params int[] values) => values.Min();
