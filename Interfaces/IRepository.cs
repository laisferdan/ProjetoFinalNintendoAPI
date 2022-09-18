namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Delete(int key);
        Task<IQueryable<T>> Get(int page, int maxResults);
        Task<T?> GetByKey(int key);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
    }
}