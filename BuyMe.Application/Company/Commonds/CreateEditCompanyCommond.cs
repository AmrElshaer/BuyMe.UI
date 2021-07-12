using BuyMe.Domain.Common;
using MediatR;

namespace BuyMe.Application.Company.Commonds
{
    public class CreateEditCompanyCommond : AuditableEntity, IRequest<int>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Business { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
    }
}