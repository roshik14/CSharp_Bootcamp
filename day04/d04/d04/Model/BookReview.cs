using System.Text.Json.Serialization;

namespace d04.Model
{
    internal class BookReview : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("author")]
        public string Author { get; set; } = "";

        [JsonPropertyName("description")]
        public string SummaryShort { get; set; } = "";

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("list_name")]
        public string ListName { get; set; } = "";

        [JsonPropertyName("amazon_product_url")]
        public string Url { get; set; } = "";

        public override string ToString() =>
            $"- {Title} by {Author} [{Rank} on NYT's {ListName}]\n"
                + $"{SummaryShort}\n"
                + $"{Url}\n";
    }
}
