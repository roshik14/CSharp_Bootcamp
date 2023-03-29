using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace d05.Nasa
{
    public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private readonly HttpClient _httpClient = new();

        public string StatusCode { get; private set; } = "";

        public string ErrorContent { get; private set; } = "";
        public string RequestUrl { get; private set; } = "https://api.nasa.gov/planetary/apod";

        public ApodClient(string apiKey)
        {
            RequestUrl += $"?&api_key={apiKey}";
        }

        public async Task<MediaOfToday[]> GetAsync(int input)
        {
            var response = await _httpClient.GetAsync($"{RequestUrl}&count={input}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != null)
                {
                    return JsonSerializer.Deserialize<MediaOfToday[]>(json)?.OrderBy(x => x.Date).ToArray()
                        ?? Array.Empty<MediaOfToday>();
                }
            }
            else
            {
                ErrorContent = await response.Content.ReadAsStringAsync();
                StatusCode = response.StatusCode.ToString();
            }
            return Array.Empty<MediaOfToday>();
        }
    }
}
