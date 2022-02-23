using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.User.Commonds.ChangePassword
{
    public class ChangePasswordCommond:IRequest<Unit>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReTypePassword { get; set; }
        public class ChangePasswordCommondHandler : IRequestHandler<ChangePasswordCommond, Unit>
        {
            private readonly ICurrentUserService currentUser;
            private readonly IApplicationUserServcie applicationUserServcie;

            public ChangePasswordCommondHandler(ICurrentUserService currentUser,IApplicationUserServcie applicationUserServcie)
            {
                this.currentUser = currentUser;
                this.applicationUserServcie = applicationUserServcie;
            }
            public async Task<Unit> Handle(ChangePasswordCommond request, CancellationToken cancellationToken)
            {
                await this.applicationUserServcie.ChangePassword(currentUser.UserId, request.OldPassword, request.NewPassword);
                return Unit.Value;
            }
        }
    }
}
