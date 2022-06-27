using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Commonds.CreatEditBranch
{
    public class CreatEditBranchCommondHandler : IRequestHandler<CreatEditBranchCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatEditBranchCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreatEditBranchCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Branch branch;
            if (request.BranchId.HasValue)
            {
                var entity = await _context.Branches.FindAsync(request.BranchId);
                Guard.Against.Null(entity, request.CurrencyId);
                branch = entity;
            }
            else
            {
                branch = new Domain.Entities.Branch();
                branch.CompanyId = _currentUserService.CompanyId;
                await _context.Branches.AddAsync(branch);
            }
            branch.BranchName = request.BranchName;
            branch.Address = request.Address;
            branch.City = request.City;
            branch.ContactPerson = request.ContactPerson;
            branch.Email = request.Email;
            branch.Phone = request.Phone;
            branch.State = request.State;
            branch.ZipCode = request.ZipCode;
            branch.CurrencyId = request.CurrencyId;
            branch.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return branch.BranchId;
        }
    }
}