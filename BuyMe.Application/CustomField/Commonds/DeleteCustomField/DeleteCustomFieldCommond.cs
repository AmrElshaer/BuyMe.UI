using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.CustomerType.Commonds.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomField.Commonds.DeleteCustomField
{
    public class DeleteCustomFieldCommond:IRequest<Unit>
    {
        public int CustomFieldId { get; set; }

        public class DeleteCustomFieldCommondHandler : IRequestHandler<DeleteCustomFieldCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteCustomFieldCommondHandler(IBuyMeDbContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(DeleteCustomFieldCommond request, CancellationToken cancellationToken)
            {
                var customField = await _context.CustomFields.FindAsync(request.CustomFieldId);
                Guard.Against.Null(customField, request.CustomFieldId);
                _context.CustomFields.Remove(customField);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
