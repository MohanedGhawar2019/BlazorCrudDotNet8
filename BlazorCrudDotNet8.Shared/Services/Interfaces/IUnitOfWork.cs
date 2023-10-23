namespace BlazorCrudDotNet8.Shared.Services.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGRepository<T> Entity { get; }
        Task SaveAsync();
    }
}
