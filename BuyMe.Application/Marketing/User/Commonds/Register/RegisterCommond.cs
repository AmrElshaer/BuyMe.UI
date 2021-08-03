using BuyMe.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Marketing.User.Commonds.Register
{
    public class RegisterCommond:IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
