using GamblingAPI.Models;

namespace GamblingAPI.Calculations
{
    public interface IHandleResponse
    {
        GamblingResponse GetResponse(GamblingRequest request, GamblingResult result, string message);
    }
}