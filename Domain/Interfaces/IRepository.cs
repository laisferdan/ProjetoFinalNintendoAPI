namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> DeleteAsync(T entity);
        Task<IQueryable<T>> GetAsync(int page, int pageLimit);
        Task<T?> GetAsyncById(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}