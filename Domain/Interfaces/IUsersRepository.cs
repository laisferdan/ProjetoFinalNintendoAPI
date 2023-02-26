using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IUsersRepository<T> where T : class
    {
        Task<IQueryable<T>> GetUserAsyncWithPagination(int page, int pageLimit);
        Task<T?> GetUserAsyncByNameAndPassword(string username, string password);
        Task<T> InsertUserAsync(T user);
    }
}