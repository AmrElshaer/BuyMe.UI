using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class GetTemplatesQueries : IRequest<QueryResult<TemplateDto>>
    {
        public DataManager DM { get; set; }

        public GetTemplatesQueries()
        {
            DM ??= new DataManager();
        }

        public class GetTemplatesQueriesHandler : IRequestHandler<GetTemplatesQueries, QueryResult<TemplateDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetTemplatesQueriesHandler(IBuyMeDbContext context, IMapper mapper, ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }

            public async Task<QueryResult<TemplateDto>> Handle(GetTemplatesQueries request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Templates.AsQueryable();
                if (!string.IsNullOrEmpty(request.DM.SearchValue))
                {
                    dataSource = dataSource.Where(a =>
                    a.Name.Contains(request.DM.SearchValue)
                    );
                }
                if (request.DM.Skip != null && request.DM.Skip != 0) dataSource = dataSource.Skip(request.DM.Skip.Value);
                if (request.DM.Take != null && request.DM.Take != 0) dataSource = dataSource.Take(request.DM.Take.Value);
                int count = dataSource.Count();
                var templateDtos = dataSource.OrderByDescending(a => a.Id).Select(_mapper.Map<TemplateDto>).ToList();
                return new QueryResult<TemplateDto>() { count = count, result = templateDtos };
            }
        }
    }
}