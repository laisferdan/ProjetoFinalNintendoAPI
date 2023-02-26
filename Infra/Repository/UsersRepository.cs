using ProjetoFinalNintendoAPI.Data;
using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalNintendoAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly InMemoryContext _context;
        public UsersRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<UsersModel>> GetUserAsyncWithPagination(int page, int pageLimit)
        {
                var users = _context.Set<UsersModel>().AsQueryable().Skip((page - 1) * pageLimit).Take(pageLimit);
                return await users.AnyAsync() ? users : new List<UsersModel>().AsQueryable();
        }

        public async Task<UsersModel?> GetUserAsyncByNameAndPassword(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(item => item.Username.Equals(username) && item.Password.Equals(password));
            return user;
        }

        public async Task<UsersModel> InsertUserAsync(UsersModel user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}