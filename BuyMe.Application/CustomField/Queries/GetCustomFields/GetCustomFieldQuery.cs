using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomField.Queries.GetCustomFields
{
    public class GetCustomFieldQuery:IRequest<IList<CustomFieldDto>>
    {
        public string Category { get; set; }
        public class GetCustomFieldQueryHandler : IRequestHandler<GetCustomFieldQuery, IList<CustomFieldDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            private readonly IMapper mapper;

            public GetCustomFieldQueryHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUserService = currentUserService;
                this.mapper = mapper;
            }

            public async Task<IList<CustomFieldDto>> Handle(GetCustomFieldQuery request, CancellationToken cancellationToken)
            {
                var customFields =await _context.CustomFields.Where(a => a.CompanyId == _currentUserService.CompanyId && a.Category == request.Category).ToListAsync();
                return mapper.Map<IList<CustomFieldDto>>(customFields);
            }

            
        }
    }
}
