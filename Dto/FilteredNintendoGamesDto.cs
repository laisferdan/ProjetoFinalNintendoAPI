using System.Text.Json.Serialization;

namespace ProjetoFinalNintendoAPI.Dto
{
    public class FilteredNintendoGamesDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("developers")]
        public string Developers { get; set; }

        public FilteredNintendoGamesDto(string title, string platform, string developers)
        {
            Title = title;
            Platform = platform;
            Developers = developers;
        }
    }
}
