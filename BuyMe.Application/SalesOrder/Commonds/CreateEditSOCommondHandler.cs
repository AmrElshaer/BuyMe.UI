using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.SalesOrder.Commonds
{
    public class CreateEditSOCommondHandler : IRequestHandler<CreateEditSOCommond, long>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly INumberSequencyService _numberSequencyService;

        public CreateEditSOCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, INumberSequencyService numberSequencyService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _numberSequencyService = numberSequencyService;
        }

        public async Task<long> Handle(CreateEditSOCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.SalesOrder so;
            if (request.SalesOrderId.HasValue)
            {
                var entity = await _context.SalesOrders.FindAsync(request.SalesOrderId);
                Guard.Against.Null(entity, request.SalesOrderId);
                so = entity;
            }
            else
            {
                so = new Domain.Entities.SalesOrder();
                so.CompanyId = _currentUserService.CompanyId;
                so.SalesOrderName = await _numberSequencyService.GetCurrentNumberSequence("SO");
                await _context.SalesOrders.AddAsync(so);
            }

            so.Amount = request.Amount;
            so.BranchId = request.BranchId;
            so.CurrencyId = request.CurrencyId;
            so.CustomerId = request.CustomerId;
            so.BranchId = request.BranchId;
            so.CurrencyId = request.CurrencyId;
            so.DeliveryDate = request.DeliveryDate;
            so.Freight = request.Freight;
            so.Tax = request.Tax;
            so.OrderDate = request.OrderDate;
            so.Remarks = request.Remarks;
            so.SalesTypeId = request.SalesTypeId;
            so.SubTotal = request.SubTotal;
            so.CurrencyCode = request.CurrencyCode;
            so.Discount = request.Discount;
            await _context.SaveChangesAsync(cancellationToken);
            return so.SalesOrderId;
        }
    }
}