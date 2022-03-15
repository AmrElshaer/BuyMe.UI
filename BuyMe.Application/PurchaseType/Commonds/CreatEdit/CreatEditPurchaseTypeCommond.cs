using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.ShipmentType.Commonds.CreateEdit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PurchaseType.Commonds.CreatEdit
{
    public class CreatEditPurchaseTypeCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class CreatEditPurchaseTypeCommondHandler : IRequestHandler<CreatEditPurchaseTypeCommond, int>
        {
           
             private readonly IBuyMeDbContext _context;
           

            public CreatEditPurchaseTypeCommondHandler(IBuyMeDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreatEditPurchaseTypeCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.PurchaseType purchaseType;
                if (request.Id.HasValue)
                {
                    var entity = await _context.PurchaseTypes.FindAsync(request.Id);
                    Guard.Against.Null(entity, request.Id);
                    purchaseType = entity;
                }
                else
                {
                    purchaseType = new Domain.Entities.PurchaseType();
                    await _context.PurchaseTypes.AddAsync(purchaseType);
                }
                purchaseType.Update(request.Name,request.Description);
                await _context.SaveChangesAsync(cancellationToken);
                return purchaseType.Id;
            }



        }
    }
}
