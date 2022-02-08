using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Controllers
{

    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DevGamesContext context;
        public PostsController(DevGamesContext context)
        {
            this.context = context;
        }

        // api/boards/1/posts
        // o id e o identificador do board
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var posts = await context.Posts.Where(p => p.BoardId == id).ToListAsync();

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(int id, int postId)
        {
            var post = await context
                .Posts
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == postId);
            if (post == null)
                return NotFound();


            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, AddPostInputModel model)
        {
            var post = new Post(id, model.Title, model.Description);

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = post.Id, postId = post.Id }, model);
        }

        // POST - api/boards/1/posts/1/comments 
        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> PostComment(int id, int postId, AddCommentInputModel model)
        {
            var postExists = await context.Posts.AnyAsync(p => p.Id == postId);
            if (!postExists)
                NotFound();

            var comment = new Comment(model.Title, model.Description, model.User, postId);

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
