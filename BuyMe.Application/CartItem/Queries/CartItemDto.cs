using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Application.Product.Queries;

namespace BuyMe.Application.CartItem.Queries
{
    public class CartItemDto : IMapFrom
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int QTN { get; set; }
        public int CompanyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CartItem, CartItemDto>();
        }
    }
}