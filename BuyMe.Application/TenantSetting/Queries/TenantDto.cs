using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Entities;

public class TenantDto : IMapFrom
{
    public int Id { get; set; }
    public string TenantName { get; set; }
    public string TenantLogo { get; set; }
    public string ConnectionString { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tenant, TenantDto>();
    }
}