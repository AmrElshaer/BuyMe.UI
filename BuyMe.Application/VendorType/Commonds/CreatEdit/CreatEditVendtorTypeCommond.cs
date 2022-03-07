using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.VendorType.Commonds.CreatEdit
{
    public class CreatEditVendtorTypeCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class CreatEditVendtorTypeCommondHandler : IRequestHandler<CreatEditVendtorTypeCommond, int>
        {
            private readonly IBuyMeDbContext context;

            public CreatEditVendtorTypeCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreatEditVendtorTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.VendorType   entity;
                if (request.Id.HasValue)
                {
                    var venType = await context.VendorTypes.FindAsync(request.Id);
                    Guard.Against.Null(venType, "ID");
                    entity = venType;
                }
                else
                {
                    entity = new();
                    context.VendorTypes.Add(entity);
                }
                entity.Name = request.Name;
                entity.Description = request.Description;
                await context.SaveChangesAsync();
                return entity.Id;

            }
        }
    }
}
