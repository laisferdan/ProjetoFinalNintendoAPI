using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IUsersRepository
    {
        Task<IQueryable<UsersModel>> GetUserAsyncWithPagination(int page, int pageLimit);
        Task<UsersModel> GetUserAsyncByNameAndPassword(string username, string password);
        Task<UsersModel> InsertUserAsync(UsersModel user);
    }
}