using GamblingAPI.Models;

namespace GamblingAPI.Calculations
{
    public class ValidateRequest : IValidateRequest
    {
        private readonly IPlayersRepo _players;

        public ValidateRequest(IPlayersRepo playersRepo)
        {
            this._players = playersRepo;
        }

        public int Validate(GamblingRequest _request)
        {
            if (_request.PlayerID == 0) return 1;
            Player? player = _players.GetPlayerByID(_request.PlayerID);
            if (player == null) return 2;
            if (_request.BetPoints == 0) return 3;
            if (_request.BetNumber < 0 || _request.BetNumber > 9) return 4;
            if (_request.BetPoints > player.CurrentPoints) return 5;
            if (player.CurrentPoints == 0 && player.OpeningPoints == 0) return 6;
            return 0;
        }
    }
}
