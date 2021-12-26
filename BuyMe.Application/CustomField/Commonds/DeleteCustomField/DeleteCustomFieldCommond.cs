using AutoMapper;
using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
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
    public class DeleteCustomFieldCommond : IRequest<Unit>
    {
        public int CustomFieldId { get; set; }

        public class DeleteCustomFieldCommondHandler : IRequestHandler<DeleteCustomFieldCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper mapper;

            public DeleteCustomFieldCommondHandler(IBuyMeDbContext context, IMapper mapper)
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
                var allCustomFieldData = await _context.CustomFieldDatas.Where(a => a.Category == customField.Category).ToListAsync();
                var allcustomFieldDatasDto = mapper.Map<List<CustomFieldDataDto>>(allCustomFieldData);
                allcustomFieldDatasDto.ForEach(a => a.Value = GetAllExpectThisFieldName(customField.FieldName, a.Value));
                allcustomFieldDatasDto.ForEach((a) => UpDeleteCustomFieldData(a));
            }

            private List<CustomColumnModel> GetAllExpectThisFieldName(string fieldName, IList<CustomColumnModel> a)
            {
                return a.Where(c => c.FieldName != fieldName).ToList();
            }

            private void UpDeleteCustomFieldData(CustomFieldDataDto a)
            {
                if (a.Value.Any()) UpdateValue(a); else DeleteCusFieldData(a);
            }

            private void DeleteCusFieldData(CustomFieldDataDto a)
            {
                var cus = _context.CustomFieldDatas.Find(a.Id);
                _context.CustomFieldDatas.Remove(cus);
            }

            private void UpdateValue(CustomFieldDataDto a)
            {
                var cus = _context.CustomFieldDatas.Find(a.Id);
                cus.Value = JsonConvert.SerializeObject(a.Value);
            }
        }
    }
}