using System.Text.Json.Serialization;

namespace ProjetoFinalNintendoAPI.Dto
{
    public class NintendoGamesDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("platform")]
        public string Platform { get; set; }
        [JsonPropertyName("release_date")]
        public string Release_Date { get; set; }
        [JsonPropertyName("user_score")]
        public string User_Score { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("developers")]
        public string Developers { get; set; }

        public NintendoGamesDto(string title, string platform, string release_Date, string user_Score, string link, string developers)
        {
            Title = title;
            Platform = platform;
            Release_Date = release_Date;
            User_Score = user_Score;
            Link = link;
            Developers = developers;
        }
    }
}