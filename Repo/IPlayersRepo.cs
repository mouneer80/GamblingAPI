using GamblingAPI.Models;

namespace GamblingAPI.Repo
{
    public interface IPlayersRepo
    {
        Player? GetPlayerByID(int playerId);
        Task<IEnumerable<Player>> GetPlayers();
        void UpdatePlayerCurrentPoints(int betPoints, Player player);
        void UpdatePlayerCurrentPoints(int betPoints, Player player, int win);
    }
}