using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrderLine.Commonds
{
    public class CreatEditSOLineCommondHandler : IRequestHandler<CreatEditSOLineCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ISalesOrderService _salesOrderService;

        public CreatEditSOLineCommondHandler(IBuyMeDbContext context, ISalesOrderService salesOrderService)
        {
            _context = context;
            _salesOrderService = salesOrderService;
        }

        private CreatEditSOLineCommond Recalculate(CreatEditSOLineCommond salesOrderLine)
        {
            try
            {
                salesOrderLine.Amount = salesOrderLine.Quantity * salesOrderLine.Price;
                salesOrderLine.DiscountAmount = (salesOrderLine.DiscountPercentage * salesOrderLine.Amount) / 100.0;
                salesOrderLine.SubTotal = salesOrderLine.Amount - salesOrderLine.DiscountAmount;
                salesOrderLine.TaxAmount = (salesOrderLine.TaxPercentage * salesOrderLine.SubTotal) / 100.0;
                salesOrderLine.Total = salesOrderLine.SubTotal + salesOrderLine.TaxAmount;
            }
            catch (Exception)
            {
                throw;
            }

            return salesOrderLine;
        }

        public async Task<int> Handle(CreatEditSOLineCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.SalesOrderLine soLine;
            if (request.SalesOrderLineId.HasValue)
            {
                var entity = await _context.SalesOrderLines.FindAsync(request.SalesOrderLineId);
                Guard.Against.Null(entity, request.SalesOrderLineId);
                soLine = entity;
            }
            else
            {
                soLine = new Domain.Entities.SalesOrderLine();
                await _context.SalesOrderLines.AddAsync(soLine);
            }
            this.Recalculate(request);
            soLine.Price = request.Price;
            soLine.SalesOrderId = request.SalesOrderId;
            soLine.ProductId = request.ProductId;
            soLine.Description = request.Description;
            soLine.Quantity = request.Quantity;
            soLine.DiscountPercentage = request.DiscountPercentage;
            soLine.TaxPercentage = request.TaxPercentage;
            soLine.Amount = request.Amount;
            soLine.DiscountAmount = request.DiscountAmount;
            soLine.SubTotal = request.SubTotal;
            soLine.TaxAmount = request.TaxAmount;
            soLine.Total = request.Total;
            await _context.SaveChangesAsync(cancellationToken);
            await _salesOrderService.UpdateSalesOrderAsync(request.SalesOrderId);
            return soLine.SalesOrderLineId;
        }
    }
}