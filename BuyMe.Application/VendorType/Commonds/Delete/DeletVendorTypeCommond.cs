using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.VendorType.Commonds.Delete
{
    public class DeletVendorTypeCommond:IRequest<Unit>
    {
        public int VendorTypeId { get; set; }
        public class DeletVendorTypeCommondHandler : IRequestHandler<DeletVendorTypeCommond, Unit>
        {
            private readonly IBuyMeDbContext context;

            public DeletVendorTypeCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(DeletVendorTypeCommond request, CancellationToken cancellationToken)
            {
                var entity = await context.VendorTypes.FindAsync(request.VendorTypeId);
                Guard.Against.Null(entity, "VendorTypeId");
                context.VendorTypes.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
