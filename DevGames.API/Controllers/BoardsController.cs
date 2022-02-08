using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using DevGames.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBoardRepository repository;

        public BoardsController(IMapper mapper, IBoardRepository boardRepository)
        {
            this.mapper = mapper;
            this.repository = boardRepository;
        }
        /// <summary>
        /// Get all boards
        /// </summary>
        /// <returns>Boards</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repository.GetAllAsync());
        }

        /// <summary>
        /// Get One board
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object Board</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var board = await repository.GetByIdAsync(id);
            if (board == null)
                return NotFound();

            return Ok(board);
        }

        /// <summary>
        /// Post Board
        /// </summary>
        /// <remarks>
        /// Request Body Example:
        /// {
        ///     "gameTitle": "GTA V",
        ///     "description": "Jogo de Mundo Aberto top",
        ///     "rules": "1. No SPAM."
        /// }
        /// </remarks>
        /// <param name="model">Board Data </param>
        /// <returns>Created Object</returns>
        /// <response code="201">Sucess</response>
        /// <response code="400">Invalid Data</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddBoardInputModel model)
        {
            var board = mapper.Map<Board>(model);

            await repository.AddAsync(board);

            return CreatedAtAction("GetById", new { id = board.Id }, model); ;
        }

        /// <summary>
        /// Update Description and Rules
        /// </summary>
        /// <remarks>
        /// {
        ///     "description": "Atualização de Descrição do Jogo",
        ///     "rules": "1. Sem regra! 2.Joguem"
        /// }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>No Content</returns>
        /// <response code="200">OK</response>
        // PUT api/boards/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, UpdateBoardInputModel model)
        {
            var board = await repository.GetByIdAsync(id);
            if (board == null)
                return NotFound();

            board.Update(model.Description, model.Rules);

            await repository.UpdateAsync(board);

            return NoContent();
        }

    }
}
