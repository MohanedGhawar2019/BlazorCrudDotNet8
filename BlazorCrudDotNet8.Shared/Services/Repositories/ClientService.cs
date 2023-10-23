using BlazorCrudDotNet8.Shared.Services.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Shared.Services.Repositories
{
    public class ClientService<T> : IClientService<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IQueryable<T> GetAll()
        {
            var result = _httpClient.GetFromJsonAsync<T[]>("api/games");
            return result.Result!.AsQueryable();
        }

        public Task<T> GetByIdAsync(object id)
        {
            var result = _httpClient.GetFromJsonAsync<T>($"api/games/{id}");
            return result!;
        }


        public async Task<T> Insert(T entity)
        {
            var result = await _httpClient.PostAsJsonAsync<T>("api/games", entity);
            return result.Content.ReadFromJsonAsync<T>().Result;
        }

        public async Task<T> Update(T entity, T oldData)
        {
            var result = await _httpClient.PutAsJsonAsync<T>($"api/games/{oldData}", entity);
            return result.Content.ReadFromJsonAsync<T>().Result;
        }

        public async Task<T> Update1(T entity)
        {
            var result = await _httpClient.PutAsJsonAsync<T>($"api/games", entity);
            return result.Content.ReadFromJsonAsync<T>().Result;
        }

        public async Task<T> Delete(object id)
        {
            var result = await _httpClient.DeleteAsync($"api/games/{id}");
            return result.Content.ReadFromJsonAsync<T>().Result;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = _httpClient.GetFromJsonAsync<T[]>($"api/games/{predicate}");
            return result.Result!.AsQueryable();
        }

    }
}
