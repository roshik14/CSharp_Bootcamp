namespace d04.Model
{
    internal static class EnumerableExtensions
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search)
        where T : ISearchable
        {
            return list
                .Where(x => x.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
    }
}
