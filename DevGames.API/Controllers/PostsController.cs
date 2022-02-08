using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using DevGames.API.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Controllers
{

    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository repository;
        public PostsController(IPostRepository postRepository)
        {
            this.repository = postRepository;
        }

        // api/boards/1/posts
        // o id e o identificador do board
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var posts = await repository.GetAllByBoardAsync(id);

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(int id, int postId)
        {
            var post = await repository.GetByIdAsync(postId);
            if (post == null)
                return NotFound();


            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, AddPostInputModel model)
        {
            var post = new Post(id, model.Title, model.Description);

            await repository.AddAsync(post);

            return CreatedAtAction(nameof(GetById), new { id = post.Id, postId = post.Id }, model);
        }

        // POST - api/boards/1/posts/1/comments 
        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> PostComment(int id, int postId, AddCommentInputModel model)
        {
            var postExists = await repository.PostExistsAsync(postId);
            if (!postExists)
                NotFound();

            var comment = new Comment(model.Title, model.Description, model.User, postId);

            await repository.AddCommentAsync(comment);

            return NoContent();
        }
    }
}
