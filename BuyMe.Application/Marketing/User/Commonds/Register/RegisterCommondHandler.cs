using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Marketing.User.Commonds.Register
{
    public class RegisterCommondHandler : IRequestHandler<RegisterCommond, Unit>
    {
        private readonly IApplicationUserServcie _applicationUserServcie;
        private readonly IBuyMeDbContext _context;

        public RegisterCommondHandler(IApplicationUserServcie applicationUserServcie, IBuyMeDbContext context)
        {
            _applicationUserServcie = applicationUserServcie;
            _context = context;
        }

        public async Task<Unit> Handle(RegisterCommond request, CancellationToken cancellationToken)
        {

            var userId = await _applicationUserServcie.AddApplicationUser(new Common.Models.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                CompanyId = request.CompanyId

            });
            await _context.Customers.AddAsync(new Domain.Entities.Customer()
            {
                CustomerName = $"{request.FirstName} {request.LastName}",
                Email = request.Email,
                CompanyId = request.CompanyId,
                UserId = userId
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}