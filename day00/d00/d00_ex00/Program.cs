if (args.Length != 3)
{
    Console.WriteLine("Something went wrong. Check your input and retry");
    return;
}

var isFirstOk = double.TryParse(args[0], out var sum);
var isSecondOk = double.TryParse(args[1], out var rate);
var isThirdOk = int.TryParse(args[2], out var term);

if (!isFirstOk || !isSecondOk|| !isThirdOk || sum <= 0 || rate <= 0 || term <= 0)
{
    Console.WriteLine("Something went wrong. Check your input and retry");
    return;
}

var i = rate / 12 / 100;
var payment = sum * i * Math.Pow((1 + i), term) / (Math.Pow(1 + i, term) - 1);
var dt = DateTime.Now.AddMonths(1);
var date = new DateTime(dt.Year, dt.Month, 1);
var remainingDebt = sum;

for (var num = 1; num <= term; num++)
{
    var interest = (remainingDebt * rate * (date - date.AddMonths(-1)).TotalDays) / (100 * (DateTime.IsLeapYear(date.Year) ? 365 : 366));

    var principalDebt = payment - interest;
    remainingDebt -= principalDebt;
    if (num == term && remainingDebt > 0)
    {
        payment += remainingDebt;
        remainingDebt = 0;
    }
    Console.WriteLine($"{num}\t{date:MM/dd/yyyy}\t{payment:N2}\t{principalDebt:N2}\t{interest:N2}\t{remainingDebt:N2}");
    date = date.AddMonths(1);
}