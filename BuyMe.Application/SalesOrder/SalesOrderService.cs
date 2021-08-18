using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IBuyMeDbContext _context;

        public SalesOrderService(IBuyMeDbContext context)
        {
            _context = context;
        }

        public async Task UpdateSalesOrderAsync(long salesOrderId)
        {
            var salesOrder = await _context.SalesOrders.Include(a => a.SalesOrderLines).FirstOrDefaultAsync(a => a.SalesOrderId == salesOrderId);
            Guard.Against.Null(salesOrder, salesOrderId);
            salesOrder.Amount = salesOrder.SalesOrderLines.Sum(x => x.Amount);
            salesOrder.SubTotal = salesOrder.SalesOrderLines.Sum(x => x.SubTotal);
            salesOrder.Discount = salesOrder.SalesOrderLines.Sum(x => x.DiscountAmount);
            salesOrder.Tax = salesOrder.SalesOrderLines.Sum(x => x.TaxAmount);
            salesOrder.Total = salesOrder.Freight + salesOrder.SalesOrderLines.Sum(x => x.Total);
            await _context.SaveChangesAsync();
        }
    }
}