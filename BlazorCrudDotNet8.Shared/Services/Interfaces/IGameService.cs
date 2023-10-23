using BlazorCrudDotNet8.Shared.Data;

namespace BlazorCrudDotNet8.Shared.Services.Interfaces
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(Guid id);
        Task<Game> AddGame(Game game);
        Task<Game> UpdateGame(Game game);
        Task<bool> DeleteGame(Guid id);
    }
}
