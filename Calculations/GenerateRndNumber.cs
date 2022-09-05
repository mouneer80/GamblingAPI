namespace GamblingAPI.Calculations
{
    public class GenerateRndNumber : IGenerateRndNumber
    {
        public int GenerateNumber()
        {
            return RandomNumber;
        }
        private int RandomNumber { get; set; } = new Random().Next(0, 9);
    }
}
