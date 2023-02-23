using System.Text.Json.Serialization;

namespace ProjetoFinalNintendoAPI.Dto
{
    public class NintendoGamesPatchDto
    {
        [JsonPropertyName("platform")]
        public string Platform { get; set; }
        public NintendoGamesPatchDto(string platform)
        {
            Platform = platform;
        }
    }
}
