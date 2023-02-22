namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Delete(int key);
        Task<IQueryable<T>> GetAsync(int page, int limit);
        Task<T?> GetByKey(int key);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
    }
}