using ProjetoFinalNintendoAPI.Models;
using System.Text.Json;

namespace ProjetoFinalNintendoAPI.Context
{
    public class DataGenerator
    {
        private readonly InMemoryContext _inMemoryContext;
        private readonly IConfiguration _configuration;

        public DataGenerator(InMemoryContext inMemoryContext, IConfiguration configuration)
        {
            _inMemoryContext = inMemoryContext;
            _configuration = configuration;
        }

        public void GenerateInMemory()
        {
            if (!_inMemoryContext.NintendoGames.Any())
            {
                List<NintendoGamesModel> nintendoGames;
                using (StreamReader reader = new StreamReader("nintendoGamesData.json"))
                {
                    string json = reader.ReadToEnd();
                    nintendoGames = JsonSerializer.Deserialize<List<NintendoGamesModel>>(json);
                }
                _inMemoryContext.NintendoGames.AddRange(nintendoGames);
                _inMemoryContext.SaveChanges();
            }

            if (!_inMemoryContext.Users.Any())
            {
                var user = new List<UsersModel>()
                {
                    new() {Name = "Laís", Password = _configuration["UserAuthentication:password"], 
                        Username = _configuration["UserAuthentication:username"], Role = "Developer" }
                };
                _inMemoryContext.Users.AddRange(user);
                _inMemoryContext.SaveChanges();
            }
        }
    }
}