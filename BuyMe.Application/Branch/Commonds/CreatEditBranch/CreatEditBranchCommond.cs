using MediatR;

namespace BuyMe.Application.Branch.Commonds.CreatEditBranch
{
    public class CreatEditBranchCommond : IRequest<int>
    {
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public int? CompanyId { get; set; }
    }
}