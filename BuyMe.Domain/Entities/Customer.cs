namespace BuyMe.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public string Country { get; set; }
    }
}