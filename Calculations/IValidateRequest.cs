using GamblingAPI.Models;

namespace GamblingAPI.Calculations
{
    public interface IValidateRequest
    {
        int Validate(GamblingRequest request);
    }
}