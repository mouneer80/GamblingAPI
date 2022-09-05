
namespace GamblingAPI.Models
{
    public class GamblingResult : IGamblingResult
    {
        public int BetPoints { get; set; } = 0;
        public string Status { get; set; } = "Try again";
    }
}
