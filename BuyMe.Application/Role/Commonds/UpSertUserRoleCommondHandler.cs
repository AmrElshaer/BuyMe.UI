using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Role.Commonds
{
    public class UpSertUserRoleCommondHandler : IRequestHandler<UpSertUserRoleCommond, Unit>
    {
        private readonly IRoleService _roleService;

        public UpSertUserRoleCommondHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Unit> Handle(UpSertUserRoleCommond request, CancellationToken cancellationToken)
        {
            await _roleService.UpSertUserRolesAsync(request.UserId, request.Roles);
            return Unit.Value;
        }
    }
}