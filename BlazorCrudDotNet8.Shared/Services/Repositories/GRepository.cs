using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorCrudDotNet8.Shared.Services.Repositories
{
    public class GRepository<T> : IGRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> table = null;
        public GRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Object id)
        {
            return await table.FindAsync(id);
        }

        public void Delete(Object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable().AsTracking();
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }
        public void Update(T entity, T oldData)
        {
            _context.Entry(oldData).CurrentValues.SetValues(entity);
        }

        public void Update1(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).AsQueryable();
        }

    }
}
