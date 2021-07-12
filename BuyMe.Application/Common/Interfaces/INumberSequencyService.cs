using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface INumberSequencyService
    {
        Task<string> GetCurrentNumberSequence(string module);
    }
}