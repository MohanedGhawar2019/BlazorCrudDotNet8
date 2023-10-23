using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorCrudDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork<Game> _game;

        public GamesController(IUnitOfWork<Game> game)
        {
            _game = game;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _game.Entity.GetAll().ToListAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _game.Entity.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _game.Entity.Insert(game);
                await _game.SaveAsync();
                return Ok(game);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Game>> Update(Game game)
        {
            if (ModelState.IsValid)
            {
                _game.Entity.Update1(game);
                await _game.SaveAsync();
                return Ok(game);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<Game>> Delete(Guid id)
        {
            var game = await _game.Entity.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _game.Entity.Delete(game);
            await _game.SaveAsync();
            return Ok(game);
        }


    }
}
