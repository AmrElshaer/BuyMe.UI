using MediatR;
using System.Collections.Generic;

namespace BuyMe.Application.Role.Commonds
{
    public class UpSertUserRoleCommond : IRequest<Unit>
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}