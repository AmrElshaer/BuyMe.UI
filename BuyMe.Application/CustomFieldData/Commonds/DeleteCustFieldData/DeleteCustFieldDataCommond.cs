using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomFieldData.Commonds.DeleteCustFieldData
{
    public class DeleteCustFieldDataCommond: IRequest<Unit>
    {
        public int RefrenceId { get;  }
        public string  Category { get;  }
        public DeleteCustFieldDataCommond(int refrenceId,string category)
        {
            this.RefrenceId = refrenceId;
            this.Category = category;
        }
        public class DeleteCustFieldDataCommondHandler : IRequestHandler<DeleteCustFieldDataCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;

            public DeleteCustFieldDataCommondHandler(IBuyMeDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteCustFieldDataCommond request, CancellationToken cancellationToken)
            {
                var cusData =  _context.CustomFieldDatas.FirstOrDefault(a=>a.RefranceId==request.RefrenceId&&a.Category==request.Category);
                if (cusData!=null)
                {
                   _context.CustomFieldDatas.Remove(cusData);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                return Unit.Value;
            }
        }
    }
}
