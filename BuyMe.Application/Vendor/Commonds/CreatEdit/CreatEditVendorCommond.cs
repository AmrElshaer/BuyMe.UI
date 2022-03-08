using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.VendorType.Commonds.CreatEdit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Vendor.Commonds.CreatEdit
{
    public class CreatEditVendorCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int VendorTypeId { get; set; }
        public class CreatEditVendorCommondHandler : IRequestHandler<CreatEditVendorCommond, int>
        {
            private readonly IBuyMeDbContext context;

            public CreatEditVendorCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreatEditVendorCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.Vendor entity;
                if (request.Id.HasValue)
                {
                    var ven = await context.Vendors.FindAsync(request.Id);
                    Guard.Against.Null(ven, "ID");
                    entity = ven;
                }
                else
                {
                    entity = new();
                    context.Vendors.Add(entity);
                }
                entity.Name = request.Name;
                entity.City = request.City;
                entity.Email = request.Email;
                entity.Address = request.Address;
                entity.VendorTypeId = request.VendorTypeId;
                await context.SaveChangesAsync();
                return entity.Id;

            }
           
        }
    }
}
