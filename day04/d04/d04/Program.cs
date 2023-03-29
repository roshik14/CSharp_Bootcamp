using d04;
using d04.Model;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var books = DataLoadController.LoadBooks(config.GetSection("books").Value);
var movies = DataLoadController.LoadMovies(config.GetSection("movies").Value);

if (args.Length > 0 && args[0] == "best")
{
    Console.WriteLine("Best in books:");
    Console.WriteLine(FindBestBook(books));
    Console.WriteLine("Best in movies:");
    Console.WriteLine(FindBestMovie(movies));
    return;
}

Console.WriteLine("Input search text");
var input = Console.ReadLine() ?? "";

var result = books.Concat(movies)
    .Search(input)
    .GroupBy(x => x.GetType())
    .ToDictionary(x => x.Key, x => x.ToList());

if (result.Count == 0)
{
    Console.WriteLine($"There are no \"{input}\" in media today");
    return;
}

var bookType = typeof(BookReview);
foreach (var resultItem in result)
{
    if (resultItem.Key == bookType)
    {
        Console.WriteLine($"Book search result [{resultItem.Value.Count}]");
    } else
    {
        Console.WriteLine($"Movie search result [{resultItem.Value.Count}]");
    }
    foreach (var value in resultItem.Value)
    {
        Console.WriteLine(value);
    }
}

ISearchable? FindBestBook(IEnumerable<ISearchable> books)
{
    var min = books.Min(x => (x as BookReview)?.Rank);
    return books.Where(x => (x as BookReview)?.Rank == min).FirstOrDefault();
}

ISearchable? FindBestMovie(IEnumerable<ISearchable> movies)
{
    return movies
        .Where(x => (x as MovieReview)?.CriticksPick != 0)
        .FirstOrDefault();
}

