namespace GamblingAPI.Models
{
    public class GamblingResponse : IGamblingResponse
    {
        public int Account { get; set; }
        public string Status { get; set; } = "Try again";
        public int Points { get; set; }
        public string Message { get; set; } = "Not Defined";
    }
}
