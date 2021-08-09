using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Marketing.User.Commonds.Login
{
    public class LoginCommond : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
