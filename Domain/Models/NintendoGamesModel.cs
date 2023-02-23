using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoFinalNintendoAPI.Models
{
    public class NintendoGamesModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
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

        public NintendoGamesModel(int id, string title, string platform, string release_Date, string user_Score, string link, string developers)
        {
            Id = id;
            Title = title;
            Platform = platform;
            Release_Date = release_Date;
            User_Score = user_Score;
            Link = link;
            Developers = developers;
        }

        public NintendoGamesModel clone()
        {
            return (NintendoGamesModel)this.MemberwiseClone();
        }
    }
}