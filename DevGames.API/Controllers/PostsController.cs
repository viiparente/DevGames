using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers
{

    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // api/boards/1/posts
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Ok();
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int id)
        {
            return Ok();
        }

        // POST - api/boards/1/posts/1/comments 
        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id, int postId)
        {
            return NoContent();
        }
    }
}
