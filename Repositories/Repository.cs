using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalNintendoAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InMemoryContext _context;

        public Repository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAsync(int page, int pageLimit)
        {
            var data =  _context.Set<T>().AsQueryable().Skip((page - 1) * pageLimit).Take(pageLimit);
            return await data.AnyAsync() ? data : new List<T>().AsQueryable();
        }

        public async Task<T?> GetAsyncById(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}