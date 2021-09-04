using MediatR;

namespace BuyMe.Application.Marketing.User.Commonds.Login
{
    public class LoginCommond : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}