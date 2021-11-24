using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomFieldData.Queries.GetCustFieldData
{
    public class GetCustFieldDataQuery : IRequest<CustomFieldDataDto>
    {
        public string Category { get; init; }
        public int RefranceId { get; init; }
        public GetCustFieldDataQuery(string category, int refranceId)
        {
            this.Category = category;
            this.RefranceId = refranceId;
        }
        public class GetCustomFieldDataQueryHandler : IRequestHandler<GetCustFieldDataQuery, CustomFieldDataDto>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            private readonly IMapper mapper;

            public GetCustomFieldDataQueryHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUserService = currentUserService;
                this.mapper = mapper;
            }

            public async Task<CustomFieldDataDto> Handle(GetCustFieldDataQuery request, CancellationToken cancellationToken)
            {
                var customFieldData = await _context.CustomFieldDatas.FirstOrDefaultAsync(a => a.CompanyId == _currentUserService.CompanyId &&
                a.Category == request.Category && a.RefranceId == request.RefranceId);
                return mapper.Map<CustomFieldDataDto>(customFieldData);
            }
        }
    }
}
