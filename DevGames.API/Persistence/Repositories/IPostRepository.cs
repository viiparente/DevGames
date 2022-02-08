using DevGames.API.Entities;

namespace DevGames.API.Persistence.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllByBoardAsync(int boardId);
        Task<Post> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task AddCommentAsync(Comment comment);
        Task<bool> PostExistsAsync(int postId);
    }
}
