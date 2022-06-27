using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Branch.Commonds.DeleteBranch
{
    public class DeleteBranchCommond : IRequest<Unit>
    {
        public int BranchId { get; set; }

        public class DeleteEmployeeCommondHandler : IRequestHandler<DeleteBranchCommond, Unit>
        {
            private readonly IBuyMeDbContext context;

            public DeleteEmployeeCommondHandler(IBuyMeDbContext context) => this.context = context;

            public async Task<Unit> Handle(DeleteBranchCommond request, CancellationToken cancellationToken)
            {
                var branch = await context.Branches.FindAsync(request.BranchId);
                Guard.Against.Null(branch, request.BranchId);
                context.Branches.Remove(branch);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}