using System.Text.Json.Serialization;

namespace d04.Model
{
    internal class MovieReview : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("critics_pick")]
        public int CriticksPick { get; set; }

        [JsonPropertyName("summary_short")]
        public string SummaryShort { get; set; } = "";

        [JsonPropertyName("url")]
        public string Url { get; set; } = "";

        public override string ToString() =>
            $"- {Title}" + (CriticksPick != 0 ? "[NYT critic's pick]" : "") + "\n"
               + $"{SummaryShort}\n"
               + $"{Url}\n";
    }
}
