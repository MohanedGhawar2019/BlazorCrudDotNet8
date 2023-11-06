using BlazorCrudDotNet8.Shared.ViewModels;

namespace BlazorCrudDotNet8.Client.Services.Interfaces
{
    public interface IGRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string url);
        Task<T> GetByIdAsync(string url, Guid id);
        Task<ResponseModel> Insert(string url, T data);
        Task<ResponseModel> Update(string url, T data, Guid id);
        Task<ResponseModel> Delete(string url, Guid id);

    }
}
