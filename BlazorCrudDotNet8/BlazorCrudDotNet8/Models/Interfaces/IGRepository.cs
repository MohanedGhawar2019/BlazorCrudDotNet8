using System.Linq.Expressions;

namespace BlazorCrudDotNet8.Models.Interfaces
{
    public interface IGRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Object id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
