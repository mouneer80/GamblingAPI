using GamblingAPI.Data;

namespace GamblingAPI.Calculations
{
    public class HandleRequest : IHandleRequest
    {
        private readonly IGenerateRndNumber _rndNumber;

        public HandleRequest(IGenerateRndNumber rndNumber)
        {
            this._rndNumber = rndNumber;
        }
        public int[] Gambling(int betNumber, int betPoints)
        {
            int generatedNumber = _rndNumber.GenerateNumber();
            int[] result = new int[2];
            result[0] = generatedNumber;
            result[1] = 0;
            if (generatedNumber == betNumber)
            {
                result[1] = Winner(betPoints);
            }
            return result;
        }
        private int Winner(int betPoints)
        {
            int points = betPoints * 9;
            return points;
        }
    }
}
