using BlazorCrudDotNet8.Client.Services.Interfaces;
using BlazorCrudDotNet8.Shared.ViewModels;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Client.Services.Repositories
{
    public class GRepository<T> : IGRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "https://localhost:7157/api/";

        public GRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetAll(string url)
        {
            return await _httpClient.GetFromJsonAsync<T[]>(BasePath + url);
        }

        public async Task<T> GetByIdAsync(string url, Guid id)
        {
            return await _httpClient.GetFromJsonAsync<T>(BasePath + url + "/" + id);
        }

        public async Task<ResponseModel> Insert(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(BasePath + url, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            else
            {
                var resModel = new ResponseModel();
                return resModel;
            }

        }

        public async Task<ResponseModel> Update(string url, T data, Guid id)
        {
            var response = await _httpClient.PutAsJsonAsync(BasePath + url + "/" + id, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            else
            {
                var resModel = new ResponseModel();
                return resModel;
            }
        }

        public async Task<ResponseModel> Delete(string url, Guid id)
        {
            var response = await _httpClient.DeleteAsync(BasePath + url + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            else
            {
                var resModel = new ResponseModel();
                return resModel;
            }
        }


    }
}
