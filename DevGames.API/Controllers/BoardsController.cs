using DevGames.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // ou NotFound();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            // Location api/boards/1
            return CreatedAtAction("GetById", new { id = model.Id }, model); ;
        }

        // PUT api/boards/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            return NoContent();
        }

        // Delete api/boards/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
