using System.Globalization;

using d02_ex00;

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

var input = args[0].Split(' ');
var isAmountParsed = double.TryParse(input[0], out var amount);
if (input.Length != 2 || !isAmountParsed)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}
var sum = new ExchangeSum { Amount = amount, Identifier = input[1] };
var exchanger = new Exchanger();

var isParsed = exchanger.ParseRatesFrom(args[1]);
if (!isParsed)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

foreach (var exchangeSum in exchanger.ConvertFrom(sum))
{
    Console.WriteLine(exchangeSum);
}
