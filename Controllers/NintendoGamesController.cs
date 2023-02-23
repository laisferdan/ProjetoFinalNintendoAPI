using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalNintendoAPI.Dto;
using ProjetoFinalNintendoAPI.Filters;
using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace ProjetoFinalNintendoAPI.Controllers
{
    [ApiController, Authorize]
    [Route("[controller]")]
    public class NintendoGamesController : ControllerBase, INintendoController<FilteredNintendoGamesDto, NintendoGamesDto, NintendoGamesPatchDto>
    {
        private readonly IRepository<NintendoGamesModel> _repository;
        public NintendoGamesController(IRepository<NintendoGamesModel> repository)
        {
            _repository = repository;
        }

        private NintendoGamesModel UpdateNintendoGamesModel(NintendoGamesModel newData, NintendoGamesDto entity)
        {
            newData.Title = entity.Title;
            newData.Platform = entity.Platform;
            newData.Release_Date = entity.Release_Date;
            newData.User_Score = entity.User_Score;
            newData.Link = entity.Link;
            newData.Developers = entity.Developers;
            return newData;
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SearchAndFilterRecordsWithPagination([FromBody] FilteredNintendoGamesDto entity, [FromQuery] int page, int pageLimit)
        {
            var games = await _repository.GetAsync(page, pageLimit);
            var filtered = games.Where(g => g.Title.Contains(entity.Title) || 
            g.Platform.Contains(entity.Platform) || 
            g.Developers.Contains(entity.Developers)).ToList();

            if (filtered.Count < 1)
                throw new KeyNotFoundException();

            return Ok(filtered);
        }

        [HttpGet]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllRecordsWithPagination([FromQuery, Required] int page, [FromQuery, Required] int pageLimit)
        {
            var games = await _repository.GetAsync(page, pageLimit);
            if (games == null)
                return NotFound("Records not found.");

            return Ok(games);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecordById([FromRoute] int id)
        {
            var game = await _repository.GetAsyncById(id);
            if (game == null)
                return NotFound("Record not found.");

            return Ok(game);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json, new[] { "application/xml", "text/plain" })]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> CreateNewRecord([FromBody] NintendoGamesDto entity)
        {
            var gamesToInsert = new NintendoGamesModel(id: 0, entity.Title, entity.Platform, entity.Release_Date, entity.User_Score, entity.Link, entity.Developers);
            var inserted = await _repository.InsertAsync(gamesToInsert);
            return Created(string.Empty, inserted);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json, new[] { "application/xml", "text/plain" })]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> UpdateExistingRecord([FromRoute] int id, NintendoGamesDto entity)
        {
            var databaseGames = await _repository.GetAsyncById(id);

            if (databaseGames == null)
            {
                var gameToInsert = new NintendoGamesModel(id: 0, entity.Title, entity.Platform, entity.Release_Date, entity.User_Score, entity.Link, entity.Developers);
                var inserted = await _repository.InsertAsync(gameToInsert);
                return Created(string.Empty, inserted);
            }

            databaseGames = UpdateNintendoGamesModel(databaseGames, entity);

            var updated = await _repository.UpdateAsync(databaseGames);

            return Ok(updated);
        }

        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json, new[] { "application/xml", "text/plain" })]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status415UnsupportedMediaType)]
        public async Task<IActionResult> UpdatePlatformOfExistingRecord([FromRoute] int id, [FromBody] NintendoGamesPatchDto entity)
        {
            var databaseGames = await _repository.GetAsyncById(id);
            if (databaseGames == null)
                return NotFound("Id not found.");

            databaseGames.Platform = entity.Platform;
            var updated = await _repository.UpdateAsync(databaseGames);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NintendoGamesModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            var databaseNintendo = await _repository.GetAsyncById(id);
            if (databaseNintendo == null)
                return NotFound("Id not found.");

            await _repository.DeleteAsync(databaseNintendo);
            return Ok($"Nintendo Game of id {id} has been successfully deleted.");
        }
    }
}