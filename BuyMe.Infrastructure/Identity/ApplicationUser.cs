using Microsoft.AspNetCore.Identity;

namespace BuyMe.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int? CompanyId { get; set; }
    }
}