using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Commonds.UpdateTemplate
{
    public class UpdateCompanyTemplateCommond:IRequest<Unit>
    {
        public int TemplateId { get;private set; }

        public UpdateCompanyTemplateCommond(int templateId)
        {
            TemplateId = templateId;
        }

        public class UpdateCompanyTemplateCommondHandler : IRequestHandler<UpdateCompanyTemplateCommond, Unit>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            public UpdateCompanyTemplateCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }
            public async Task<Unit> Handle(UpdateCompanyTemplateCommond request, CancellationToken cancellationToken)
            {
                var company =await  _context.Companies.FindAsync(_currentUserService.CompanyId);
                company.TemplateId = request.TemplateId;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
