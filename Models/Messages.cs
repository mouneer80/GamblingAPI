namespace GamblingAPI.Models
{
    public class Messages : IMessages
    {
        private string[] responseMessage { get; set; } = {
            "Valid Request",
            "Player ID cannot be 0",
            "Player ID not found",
            "Cannot bet with 0 points",
            "You can only bet with integer between 0 and 9",
            "Your current balance not enough please select less points",
            "Your current points are 0"
        };

        public string GetMessage(int errorCode)
        {
            return responseMessage[errorCode];
        }
    }
}
