using System.Linq.Expressions;

namespace BlazorCrudDotNet8.Shared.Services.Interfaces
{
    public interface IClientService<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Object id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity, T oldData);
        Task<T> Update1(T entity);
        Task<T> Delete(Object id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
