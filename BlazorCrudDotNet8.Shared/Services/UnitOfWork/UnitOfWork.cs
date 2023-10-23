using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Services.Interfaces;
using BlazorCrudDotNet8.Shared.Services.Repositories;

namespace BlazorCrudDotNet8.Shared.Services.UnitOfWork
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
