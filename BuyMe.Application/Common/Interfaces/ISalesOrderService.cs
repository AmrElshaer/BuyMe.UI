using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ISalesOrderService
    {
        Task UpdateSalesOrderAsync(long salesOrderId);
    }
}