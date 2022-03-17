namespace BuyMe.Application.TenantSetting.Commonds
{
    public class TenantEvent
    {
        public const string Created = "Tenant Created";
        public const string Updated = "Tenant Updated";
        public string Name { get; set; }
    }
}
