using d04.Model;
using System.Text.Json;

namespace d04
{
    internal static class DataLoadController
    {
        public static IEnumerable<ISearchable> LoadBooks(string path)
        {
            foreach (var item in GetParsedData(path))
            {
                var book = item.Deserialize<BookReview>() ?? new BookReview();
                var bookDetail = item.GetProperty("book_details")
                    .EnumerateArray()
                    .FirstOrDefault()
                    .Deserialize<BookReview>() ?? new BookReview();
                book.Title = bookDetail.Title;
                book.Author = bookDetail.Author;
                book.SummaryShort = bookDetail.SummaryShort;
                yield return book;
            }
        }

        public static IEnumerable<ISearchable> LoadMovies(string path)
        {
            foreach (var item in GetParsedData(path))
            {
                var movie = item.Deserialize<MovieReview>() ?? new MovieReview();
                movie.Url = item.GetProperty("link").GetProperty("url").GetString() ?? "";
                yield return movie;
            }
        }

        private static JsonElement.ArrayEnumerator GetParsedData(string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            return JsonDocument.Parse(fs).RootElement.GetProperty("results").EnumerateArray();
        }
    }
}
