using DevGames.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Persistence
{
    public class DevGamesContext
    {
        public DevGamesContext()
        {
            Boards = new List<Board>();
        }

        public List<Board> Boards { get; set; }
        
    }
}