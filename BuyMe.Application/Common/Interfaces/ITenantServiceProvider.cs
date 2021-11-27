namespace BuyMe.Application.Common.Interfaces
{
    public interface ITenantServiceProvider
    {
        void GeneratTenant(string tenant);
    }
}