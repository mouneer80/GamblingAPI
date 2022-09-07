using GamblingAPI.Models;

namespace GamblingAPI.Calculations
{
    public class HandleResponse : IHandleResponse
    {
        private readonly IPlayersRepo _players;

        public HandleResponse(IPlayersRepo playersRepo)
        {
            this._players = playersRepo;
        }

        public GamblingResponse GetResponse(GamblingRequest request, GamblingResult result, string message, int genNum)
        {
            Player? player = _players.GetPlayerByID(request.PlayerID);
            GamblingResponse response = new GamblingResponse();
            response.Points = result.BetPoints;
            response.Message = message;
            response.Status = result.Status;
            response.Account = player == null ? 0 : player.CurrentPoints;
            response.GeneratedNumber = genNum;
            return response;
        }
    }
}
