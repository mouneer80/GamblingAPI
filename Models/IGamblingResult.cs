namespace GamblingAPI.Models
{
    
    public interface IGamblingResult
    {
        int BetPoints { get; set; }
        string Status { get; set; }
    }
}