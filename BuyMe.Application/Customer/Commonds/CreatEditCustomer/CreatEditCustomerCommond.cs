using MediatR;

namespace BuyMe.Application.Customer.Commonds.CreatEditCustomer
{
    public class CreatEditCustomerCommond : IRequest<int>
    {
        public int? Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CustomerTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}