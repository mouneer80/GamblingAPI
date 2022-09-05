using GamblingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamblingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepo _players;
        public PlayersController(IPlayersRepo playersRepo)
        {
            this._players = playersRepo;
        }

        [HttpGet(Name = "GetPlayers")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _players.GetPlayers());
        }
    }
}
