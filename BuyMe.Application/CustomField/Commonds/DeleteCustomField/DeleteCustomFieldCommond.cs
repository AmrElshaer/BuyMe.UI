using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.CustomerType.Commonds.Delete;
using BuyMe.Application.CustomFieldData.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            private readonly IMapper mapper;

            public DeleteCustomFieldCommondHandler(IBuyMeDbContext context,IMapper mapper)
            {
                this._context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteCustomFieldCommond request, CancellationToken cancellationToken)
            {
                var customField = await _context.CustomFields.FindAsync(request.CustomFieldId);
                Guard.Against.Null(customField, request.CustomFieldId);
                _context.CustomFields.Remove(customField);
                await RemoveCusDataAsync(customField);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }

            private async Task RemoveCusDataAsync(Domain.Entities.CustomField customField)
            {
                var customFieldDatas = mapper.Map<IList<CustomFieldDataDto>>(
                    await _context.CustomFieldDatas.Where(a => a.Category == customField.Category
                    ).ToListAsync());
                if (customFieldDatas.Any())
                {
                    customFieldDatas.ToList()
                        .ForEach(a => a.Value = a.Value.Where(c => c.FieldName != customField.FieldName).ToList());
                    customFieldDatas.ToList().ForEach((a) =>
                    {
                        var cus = _context.CustomFieldDatas.Find(a.Id);
                        if (a.Value.Any())
                        {
                            cus.Value = JsonConvert.SerializeObject(a.Value);
                        }
                        else
                        {
                            _context.CustomFieldDatas.Remove(cus);
                        }
                    });
                }
            }
        }
    }
}
