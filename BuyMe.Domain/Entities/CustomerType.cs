using System.Collections.Generic;

namespace BuyMe.Domain.Entities
{
    public class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Customer>  Customers { get; set; }
    }
}