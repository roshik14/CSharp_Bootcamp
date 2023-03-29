using System.Text.Json;
using System.Text.Json.Serialization;

namespace d05.Nasa
{
    public class MediaOfToday
    {
        [JsonPropertyName("copyright")]
        public string CopyRight { get; set; } = "";

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Explanation { get; set; } = "";

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("url")]
        public string Url { get; set; } = "";

        public override string ToString()
        {
            var copyright = string.IsNullOrEmpty(CopyRight) ? "" : $" by {CopyRight}";
            return $"{Date:dd/MM/yyyy}\n'{Title}'{copyright}\n{Explanation}\n{Url}.";
        }
    }
}
