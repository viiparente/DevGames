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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var board = await repository.GetByIdAsync(id);
            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBoardInputModel model)
        {
            var board = mapper.Map<Board>(model);

            await repository.AddAsync(board);

            return CreatedAtAction("GetById", new { id = board.Id }, model); ;
        }

        // PUT api/boards/1
        [HttpPut("{id}")]
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
