using DevGames.API.Entities;

namespace DevGames.API.Persistence.Repositories
{
    public interface IBoardRepository
    {
        Task<List<Board>> GetAllAsync();
        Task<Board> GetByIdAsync(int id);
        Task AddAsync(Board board);
        Task UpdateAsync(Board board);
    }
}