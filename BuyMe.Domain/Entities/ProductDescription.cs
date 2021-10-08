namespace BuyMe.Domain.Entities
{
    public class ProductDescription
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? CategoryDescriptionId { get; set; }
        public CategoryDescription CategoryDescription { get; set; }
        public string Description { get; set; }
    }
}