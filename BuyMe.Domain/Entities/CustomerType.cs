namespace BuyMe.Domain.Entities
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}