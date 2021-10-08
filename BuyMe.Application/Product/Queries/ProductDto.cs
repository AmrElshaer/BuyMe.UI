using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BuyMe.Application.Product.Queries
{
    public class ProductDto : IMapFrom
    {
        public ProductDto()
        {
            ProductImages = new List<ProductImageDto>();
            ProductDescriptions = new List<ProductDescriptionDto>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string Barcode { get; set; }
        public Decimal? DefaultBuyingPrice { get; set; }
        public Decimal? DefaultSellingPrice { get; set; }
        public int? CurrencyId { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public string UOM { get; set; }
        public int CompanyId { get; set; }
        public string CurrencyCode { get; set; }
        public bool AllowMarketing { get; set; }
        public IList<ProductImageDto> ProductImages { get; set; }
        public IList<ProductDescriptionDto> ProductDescriptions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>()
                .ForMember(a => a.BranchName, a => a.MapFrom(p => p.Branch.BranchName))
                .ForMember(a => a.UOM, a => a.MapFrom(p => p.UnitOfMeasure.UOM))
                .ForMember(a => a.CurrencyCode, a => a.MapFrom(p => p.Currency.CurrencyCode));
        }
    }
}