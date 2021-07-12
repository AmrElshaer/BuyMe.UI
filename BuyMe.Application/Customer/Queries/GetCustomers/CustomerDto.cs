using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.CustomerType.Queries;

namespace BuyMe.Application.Customer.Queries.GetCustomers
{
    public class CustomerDto : IMapFrom
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CustomerTypeId { get; set; }
        public int CompanyId { get; set; }
        public CustomerTypeDto CustomerType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Customer, CustomerDto>();
        }
    }
}