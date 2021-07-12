using MediatR;

namespace BuyMe.Application.Currency.Commonds.CreateEditCurrency
{
    public class CreatEditCurrencyCommond : IRequest<int>
    {
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}