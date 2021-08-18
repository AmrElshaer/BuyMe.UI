using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomerType.Commonds.CreateEdit
{
    public class CreatEditCustomerTypeCommond : IRequest<int>
    {
        public int? CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }
        public string CompanyId { get; set; }

        public class CreatEditCTCommondHandler : IRequestHandler<CreatEditCustomerTypeCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public CreatEditCTCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(CreatEditCustomerTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.CustomerType customerType;
                if (request.CustomerTypeId.HasValue)
                {
                    var entity = await _context.CustomerTypes.FindAsync(request.CustomerTypeId);
                    Guard.Against.Null(entity, request.CustomerTypeId);
                    customerType = entity;
                }
                else
                {
                    customerType = new Domain.Entities.CustomerType();
                    await _context.CustomerTypes.AddAsync(customerType);
                    customerType.CompanyId = _currentUserService.CompanyId;
                }
                customerType.CustomerTypeDescription = request.CustomerTypeDescription;
                customerType.CustomerTypeName = request.CustomerTypeName;

                await _context.SaveChangesAsync(cancellationToken);
                return customerType.Id;
            }
        }
    }
}