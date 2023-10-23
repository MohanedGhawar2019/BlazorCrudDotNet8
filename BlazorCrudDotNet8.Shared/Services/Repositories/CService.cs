using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorCrudDotNet8.Shared.Services.Repositories
{
    public class CService : IGameService
    {
        private readonly HttpClient _httpClient;

        public CService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Game> AddGame(Game game)
        {
            var response = await _httpClient.PostAsJsonAsync("api/games/", game);

            // response retun 400 bad request

            return await response.Content.ReadFromJsonAsync<Game>();

        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/games/{id}");
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<Game>> GetAllGames()
        {
            var response = await _httpClient.GetAsync("api/games");
            return await response.Content.ReadFromJsonAsync<List<Game>>();
        }

        public async Task<Game> GetGameById(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/games/{id}");
            return await response.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<Game> UpdateGame(Game game)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/games/{game.Id}", game);
            return await response.Content.ReadFromJsonAsync<Game>();
        }
    }
}
