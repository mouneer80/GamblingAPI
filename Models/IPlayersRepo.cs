namespace GamblingAPI.Models
{
    public interface IPlayersRepo
    {
        Player? GetPlayerByID(int playerId);
        Task<IEnumerable<Player>> GetPlayers();
        void UpdatePlayerCurrentPoints(int betPoints, Player player);
    }
}