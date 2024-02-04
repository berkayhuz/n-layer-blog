using HuzlabBlog.Service.Services.Abstractions;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class TranslationService : ITranslationService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> TranslateAsync(string text, string targetLanguage)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://wsbe-machine-translation-v1.p.rapidapi.com/api/mt/v1/translate"),
                Headers =
            {
                { "X-RapidAPI-Key", "4689611baemsha89ffc3c67e102cp1186ddjsna9373965a9b3" },
                { "X-RapidAPI-Host", "wsbe-machine-translation-v1.p.rapidapi.com" },
            },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "text", text },
                { "lang", targetLanguage },
            }),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
