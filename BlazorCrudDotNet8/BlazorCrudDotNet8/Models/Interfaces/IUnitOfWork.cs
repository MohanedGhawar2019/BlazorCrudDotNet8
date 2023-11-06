namespace BlazorCrudDotNet8.Models.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGRepository<T> Entity { get; }
        Task SaveAsync();
    }
}
