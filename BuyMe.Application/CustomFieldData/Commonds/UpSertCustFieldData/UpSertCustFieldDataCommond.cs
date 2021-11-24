using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomFieldData.Commonds.UpSertCustFieldData
{
    public class UpSertCustFieldDataCommond: IRequest<int>
    {
        public int RefranceId { get; set; }
        public string Category { get; set; }
        public IList<CustomColumnModel> CustomColumns { get; set; }
        public class UpSertCustomerFieldDataCommondHandler : IRequestHandler<UpSertCustFieldDataCommond, int>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public UpSertCustomerFieldDataCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(UpSertCustFieldDataCommond request, CancellationToken cancellationToken)
            {

                Domain.Entities.CustomFieldData customFieldData;
                var entity = await _context.CustomFieldDatas.FirstOrDefaultAsync(a => a.RefranceId == request.RefranceId && a.CompanyId == _currentUserService.CompanyId);
                if (entity != null)
                {
                    customFieldData = entity;
                }
                else
                {
                    customFieldData = new Domain.Entities.CustomFieldData();
                    await _context.CustomFieldDatas.AddAsync(customFieldData);
                    customFieldData.CompanyId = _currentUserService.CompanyId;
                }
                customFieldData.RefranceId = request.RefranceId;
                customFieldData.Category = request.Category;
                customFieldData.Value = JsonConvert.SerializeObject(request.CustomColumns);
                await _context.SaveChangesAsync(cancellationToken);
                return customFieldData.Id;
            }
        }
    }
}
