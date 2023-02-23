using Microsoft.EntityFrameworkCore;
using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {
        }

        public DbSet<NintendoGamesModel> NintendoGames { get; set; }
        public DbSet<UsersModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}