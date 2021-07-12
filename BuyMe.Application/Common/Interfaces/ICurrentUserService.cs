namespace BuyMe.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int CompanyId { get; }
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}