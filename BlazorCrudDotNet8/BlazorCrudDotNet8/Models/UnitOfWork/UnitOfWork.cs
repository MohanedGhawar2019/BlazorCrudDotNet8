using BlazorCrudDotNet8.Models.Interfaces;
using BlazorCrudDotNet8.Models.Repositories;

namespace BlazorCrudDotNet8.Models.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private IGRepository<T> _entity;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GRepository<T>(_context));
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}