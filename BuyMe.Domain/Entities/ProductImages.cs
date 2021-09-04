namespace BuyMe.Domain.Entities
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Image { get; set; }
    }
}