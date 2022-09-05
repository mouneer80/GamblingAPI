namespace GamblingAPI.Models
{
    public class GamblingRequest : IGamblingRequest
    {
        public int PlayerID { get; set; }
        public int BetPoints { get; set; }
        public int BetNumber { get; set; }

    }
}
