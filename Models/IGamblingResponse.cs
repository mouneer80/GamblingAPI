namespace GamblingAPI.Models
{
    public interface IGamblingResponse
    {
        int Account { get; set; }
        string Status { get; set; }
        int Points { get; set; }
        string Message { get; set; }
    }
}