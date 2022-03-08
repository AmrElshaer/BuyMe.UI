using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.VendorType.Commonds.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Vendor.Commonds.Delete
{
    public class DeletVendorCommond:IRequest<Unit>
    {
        public int VendorId { get; set; }
        public class DeletVendorCommondHandler : IRequestHandler<DeletVendorCommond, Unit>
        {
            private readonly IBuyMeDbContext context;

            public DeletVendorCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(DeletVendorCommond request, CancellationToken cancellationToken)
            {
                var entity = await context.Vendors.FindAsync(request.VendorId);
                Guard.Against.Null(entity, "VendorId");
                context.Vendors.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
           
        }
    }
}
