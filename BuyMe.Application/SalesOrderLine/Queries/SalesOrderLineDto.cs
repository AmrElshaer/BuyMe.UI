using AutoMapper;
using BuyMe.Application.Common.Mapping;

namespace BuyMe.Application.SalesOrderLine.Queries
{
    public class SalesOrderLineDto : IMapFrom
    {
        public int SalesOrderLineId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.SalesOrderLine, SalesOrderLineDto>()
                .ForMember(a => a.ProductName, a => a.MapFrom(p => p.Product.ProductName));
        }
    }
}