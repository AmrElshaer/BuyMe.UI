using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomField.Commonds.UpSertCustomField
{
    public class UpSertCustomerFieldCommond : IRequest<int>
    {
        public int? Id { get; set; }
        public string Category { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public class UpSertCustomerFieldCommondHandler : IRequestHandler<UpSertCustomerFieldCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public UpSertCustomerFieldCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(UpSertCustomerFieldCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.CustomField customField;
                if (request.Id.HasValue)
                {
                    var entity = await _context.CustomFields.FirstOrDefaultAsync(a => a.Id == request.Id);
                    Guard.Against.Null(entity, request.Id);
                    customField = entity;
                }
                else
                {
                    customField = new Domain.Entities.CustomField();
                    await _context.CustomFields.AddAsync(customField);
                    customField.CompanyId = _currentUserService.CompanyId;
                }
                customField.Category = request.Category;
                customField.FieldName = request.FieldName;
                customField.FieldType = request.FieldType;
                await _context.SaveChangesAsync(cancellationToken);
                return customField.Id;
            }
        }
    }
}