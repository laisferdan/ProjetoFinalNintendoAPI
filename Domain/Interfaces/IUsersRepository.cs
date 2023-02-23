using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UsersModel>> Get(int page, int maxResults);
        Task<UsersModel?> Get(string username, string password);
        Task<UsersModel> Insert(UsersModel user);
    }
}