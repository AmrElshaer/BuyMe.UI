using BuyMe.Application.Common.Interfaces;
using System.Security.Claims;

namespace ByMe.Presentation.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
            CompanyId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue("CompanyId"));
        }

        public int CompanyId { get; set; }
        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}