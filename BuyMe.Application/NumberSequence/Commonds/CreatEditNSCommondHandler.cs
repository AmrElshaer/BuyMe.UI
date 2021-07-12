using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.NumberSequence.Commonds
{
    public class CreatEditNSCommondHandler : IRequestHandler<CreatEditNSCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatEditNSCommondHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreatEditNSCommond request, CancellationToken cancellationToken)
        {
            var ns = await _context.NumberSequences.FirstOrDefaultAsync(a => a.Module == request.Module);
            if (ns == null)
            {
                ns = new Domain.Entities.NumberSequence();
                ns.CompanyId = _currentUserService.CompanyId;
                await _context.NumberSequences.AddAsync(ns);
            }
            ns.NumberSequenceName = request.NumberSequenceName;
            ns.LastNumber = ++ns.LastNumber;
            ns.Module = request.Module;
            ns.Prefix = request.Prefix;
            return ns.LastNumber;
        }
    }
}