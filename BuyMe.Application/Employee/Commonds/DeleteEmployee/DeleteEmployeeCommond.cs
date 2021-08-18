using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Employee.Commonds.DeleteEmployee
{
    public class DeleteEmployeeCommond : IRequest<Unit>
    {
        public int EmployeeId { get; set; }

        public class DeleteEmployeeCommondHandler : IRequestHandler<DeleteEmployeeCommond, Unit>
        {
            private readonly IBuyMeDbContext context;
            private readonly IApplicationUserServcie applicationUserServcie;

            public DeleteEmployeeCommondHandler(IBuyMeDbContext context, IApplicationUserServcie applicationUserServcie)
            {
                this.context = context;
                this.applicationUserServcie = applicationUserServcie;
            }

            public async Task<Unit> Handle(DeleteEmployeeCommond request, CancellationToken cancellationToken)
            {
                var employee = await context.Employees.FindAsync(request.EmployeeId);
                Guard.Against.Null(employee, request.EmployeeId);
                await applicationUserServcie.RemoveApplicationUser(employee.UserId);
                context.Employees.Remove(employee);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}