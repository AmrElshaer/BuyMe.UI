using MediatR;

namespace BuyMe.Application.Marketing.User.Commonds.Register
{
    public class RegisterCommond : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}