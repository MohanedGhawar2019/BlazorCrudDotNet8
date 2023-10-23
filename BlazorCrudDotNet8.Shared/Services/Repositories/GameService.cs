using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services.Repositories
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }
        public async Task<Game> AddGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Remove(game);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Game>> GetAllGames()
        {
            return await _context.Games.ToListAsync();
        }

        public Task<Game> GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
