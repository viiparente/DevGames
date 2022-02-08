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
        public IActionResult GetAll(int id)
        {
            var posts = context.Posts.Where(p => p.BoardId == id);

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            var post = context
                .Posts
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == postId);
            if (post == null)
                return NotFound();


            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(int id, AddPostInputModel model)
        {
            var post = new Post(id, model.Title, model.Description);

            context.Posts.Add(post);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = post.Id, postId = post.Id }, model);
        }

        // POST - api/boards/1/posts/1/comments 
        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id, int postId, AddCommentInputModel model)
        {
            var postExists = context.Posts.Any(p => p.Id == postId);
            if (!postExists)
                NotFound();

            var comment = new Comment(model.Title, model.Description, model.User, postId);

            context.Comments.Add(comment);
            context.SaveChanges();

            return NoContent();
        }
    }
}
