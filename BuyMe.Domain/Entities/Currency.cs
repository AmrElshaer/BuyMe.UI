namespace BuyMe.Domain.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}