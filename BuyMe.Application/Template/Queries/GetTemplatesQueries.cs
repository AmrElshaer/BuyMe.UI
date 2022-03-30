using System.Collections.Generic;
using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Template.Queries
{
    public class GetTemplatesQueries : BaseRequestQuery,IRequest<QueryResult<TemplateDto>>
    {
        public class GetTemplatesQueriesHandler : IRequestHandler<GetTemplatesQueries, QueryResult<TemplateDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetTemplatesQueriesHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<TemplateDto>> Handle(GetTemplatesQueries request, CancellationToken cancellationToken)
            {
                var res =await _context.Templates.ApplyFiliter(request,a =>
                    a.Name.Contains(request.DM.SearchValue)
                    ).ApplySkip(request).ApplyTake(request).Build(a => a.Id);
                return new QueryResult<TemplateDto>() { count = res.Count, result = _mapper.Map<IList<TemplateDto>>(res.Data) };
            }
        }
    }
}