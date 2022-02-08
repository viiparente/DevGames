using DevGames.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Persistence.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DevGamesContext context;

        public BoardRepository(DevGamesContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Board board)
        {
            await context.Boards.AddAsync(board);
            await context.SaveChangesAsync();
        }

        public async Task<List<Board>> GetAllAsync()
        {
            return await context.Boards.ToListAsync();
        }

        public async Task<Board> GetByIdAsync(int id)
        {
            return await context.Boards.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Board board)
        {
            context.Boards.Update(board);
            await context.SaveChangesAsync();
        }
    }
}