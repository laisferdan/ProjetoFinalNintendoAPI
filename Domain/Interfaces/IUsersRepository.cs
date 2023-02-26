using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IUsersRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAsync(int page, int pageLimit);
        Task<UsersModel?> Get(string username, string password);
        Task<UsersModel> Insert(UsersModel user);
    }
}