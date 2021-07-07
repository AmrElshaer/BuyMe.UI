using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (salesOrder == null) throw new NotFoundException("SalesOrder", salesOrderId);
            salesOrder.Amount = salesOrder.SalesOrderLines.Sum(x => x.Amount);
            salesOrder.SubTotal = salesOrder.SalesOrderLines.Sum(x => x.SubTotal);
            salesOrder.Discount = salesOrder.SalesOrderLines.Sum(x => x.DiscountAmount);
            salesOrder.Tax = salesOrder.SalesOrderLines.Sum(x => x.TaxAmount);
            salesOrder.Total = salesOrder.Freight + salesOrder.SalesOrderLines.Sum(x => x.Total);
            await _context.SaveChangesAsync();


        }
    }
}
