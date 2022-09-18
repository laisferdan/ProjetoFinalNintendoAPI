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

        public void Generate()
        {
            if (!_inMemoryContext.NintendoGames.Any())
            {
                List<NintendoGamesModel> items;
                using (StreamReader r = new StreamReader("nintendoGamesData.json"))
                {
                    string json = r.ReadToEnd();
                    items = JsonSerializer.Deserialize<List<NintendoGamesModel>>(json);
                }
                _inMemoryContext.NintendoGames.AddRange(items);
                _inMemoryContext.SaveChanges();
            }

            if (!_inMemoryContext.Users.Any())
            {
                var user = new List<UsersModel>()
                {
                    new() {Name = "Laís", Password = _configuration["UserAuthentication:senha"], 
                        Username = _configuration["UserAuthentication:login"], Role = "Developer" }
                };
                _inMemoryContext.Users.AddRange(user);
                _inMemoryContext.SaveChanges();
            }
        }
    }
}