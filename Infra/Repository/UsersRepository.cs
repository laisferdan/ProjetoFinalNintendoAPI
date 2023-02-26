using ProjetoFinalNintendoAPI.Data;
using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalNintendoAPI.Repository
{
    public class UsersRepository<T> : IUsersRepository<T> where T : class
    {
        private readonly InMemoryContext _context;
        public UsersRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAsync(int page, int pageLimit)
        {
                var users = _context.Set<T>().AsQueryable().Skip((page - 1) * pageLimit).Take(pageLimit);
                return await users.AnyAsync() ? users : new List<T>().AsQueryable();
        }

        public Task<UsersModel?> Get(string username, string password)
        {
            return Task.Run(() =>
            {
                var user = _context.Users.FirstOrDefault(item => item.Username.Equals(username) && item.Password.Equals(password));
                return user;
            });
        }

        public Task<UsersModel> Insert(UsersModel user)
        {
            return Task.Run(() =>
            {
                _context.Add(user);
                _context.SaveChanges();
                return user;
            });
        }
    }
}