using GamblingAPI.Calculations;
using GamblingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamblingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamblingController : ControllerBase
    {
        private readonly IValidateRequest _validateRequest;
        private readonly IHandleRequest _handleRequest;
        private readonly IHandleResponse _handleResponse;
        private readonly IMessages _message;
        private readonly IPlayersRepo _player;

        public GamblingController(IValidateRequest validateRequest, IHandleRequest handleRequest, 
            IHandleResponse handleResponse, IMessages message, IPlayersRepo player)
        {
            this._validateRequest = validateRequest;
            this._handleRequest = handleRequest;
            this._handleResponse = handleResponse;
            this._message = message;
            this._player = player;
        }

        [HttpPost(Name = "GetGamblingResult")]
        public GamblingResponse Get(GamblingRequest request)
        {
            GamblingResult gResult = new GamblingResult();
            int valid = _validateRequest.Validate(request);
            if (valid == 0)
            {
                Player? player = _player.GetPlayerByID(request.PlayerID);
                if(player != null)
                    _player.UpdatePlayerCurrentPoints(request.BetPoints, player);
                int result = _handleRequest.Gambling(request.BetNumber);
                if (result != 0)
                {
                    gResult.Status = "Won";
                    gResult.BetPoints = result;
                }
            }
            string message = _message.GetMessage(valid);
            return _handleResponse.GetResponse(request, gResult, message);
        }
    }
}