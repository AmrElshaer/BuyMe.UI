namespace BuyMe.Application.Common.Interfaces
{
    public interface IEmployeeService
    {
        bool IsEmailUnique(string email, int? id, int? companyId);
    }
}