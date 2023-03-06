using Game_API.DTO;
using Game_API.Models;
using Game_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingApiKey.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace Game_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostGame([FromBody] GameResultDTO gameResult)
        {
            var response = new GameResultDTO();

            if (gameResult == null)
            {
                return BadRequest();
            }

            try
            {
                // Save the changes to the database
                response = await _service.Post(gameResult);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            string jsonString = JsonSerializer.Serialize(response);
            // Return a response with the saved gameSession object
            return Ok(jsonString);
        }

        [HttpGet]
        [Route("nextDifficultyLevel")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> NextDifficultyLevel([Required]string userId, [Required] int playerId, [Required] string gameName)
        {
            var gameRequestDto = new GameResquestDTO { UserId = userId, PlayerId = playerId, GameName = gameName };
            // Get the game object with the specified id
            var gameSession = await _service.Get(gameRequestDto);

            // If no game object is found, return a 404 error
            if (gameSession == null)
            {
                return NotFound();
            }

            string jsonString = JsonSerializer.Serialize(gameSession);
            // Return the game object
            return Ok(jsonString);
        }
    }
}
