using GamblingAPI.Models;

namespace GamblingAPI.Calculations
{
    public class HandleRequest : IHandleRequest
    {
        private readonly IGamblingRequest _request;
        private readonly IGenerateRndNumber _rndNumber;

        public HandleRequest(IGamblingRequest request, IGenerateRndNumber rndNumber)
        {
            this._request = request;
            this._rndNumber = rndNumber;
        }
        public int Gambling(int betNumber)
        {
            int generatedNumber = _rndNumber.GenerateNumber();
            if (generatedNumber == _request.BetNumber) return Winner();
            return 0;
        }
        private int Winner()
        {
            int points = _request.BetPoints * 9;
            return points;
        }

    }
}
