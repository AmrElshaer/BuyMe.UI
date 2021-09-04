using BuyMe.Application.Company.Queries;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IGenerateManifestService
    {
        object GenerateManifest(CompanyDto company);
    }
}