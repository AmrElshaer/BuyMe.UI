namespace BuyMe.Domain.Entities
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}