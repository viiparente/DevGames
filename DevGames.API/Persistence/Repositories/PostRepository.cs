using DevGames.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DevGamesContext context;

        public PostRepository(DevGamesContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Post post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }
        public async Task<List<Post>> GetAllByBoardAsync(int boardId)
        {
            return await context.Posts.Where(p => p.BoardId == boardId).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await context
                .Posts
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task<bool> PostExistsAsync(int postId)
        {
            return await context.Posts.AnyAsync(p => p.Id == postId);
        }
    }
}