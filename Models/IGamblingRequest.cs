namespace GamblingAPI.Models
{
    public interface IGamblingRequest
    {
        int BetNumber { get; set; }
        int BetPoints { get; set; }
        int PlayerID { get; set; }
    }
}