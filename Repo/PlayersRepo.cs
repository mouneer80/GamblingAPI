using GamblingAPI.Data;
using GamblingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamblingAPI.Repo
{
    public class PlayersRepo : IPlayersRepo
    {
        #region Private members
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public PlayersRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        #region Public methods
        public Player? GetPlayerByID(int playerId)
        {
            Player? player = _appDbContext.Palyers.FirstOrDefault(p => p.ID == playerId);
            if (player != null && player.OpeningPoints != 0) SetCurrentPoints(player);
            return player;
        }
        private Player SetCurrentPoints(Player player)
        {
            player.CurrentPoints = player.OpeningPoints;
            player.OpeningPoints = 0;
            _appDbContext.SaveChangesAsync();
            return player;
        }
        public void UpdatePlayerCurrentPoints(int betPoints, Player player)
        {
            player.CurrentPoints = player.CurrentPoints - betPoints;
            _appDbContext.SaveChangesAsync();
        }
        public void UpdatePlayerCurrentPoints(int betPoints, Player player, int win)
        {
            player.CurrentPoints = player.CurrentPoints + betPoints;
            _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _appDbContext.Palyers.ToListAsync();
        }
        #endregion
    }
}

