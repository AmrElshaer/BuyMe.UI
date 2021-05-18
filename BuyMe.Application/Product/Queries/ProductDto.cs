using AutoMapper;
using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.Currency.Queries;
using BuyMe.Application.UnitOfMeasure.Queries;
using BuyMe.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Product.Queries
{
    public class ProductDto:IMapFrom
    {
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
        public string  UOM { get; set; }
        public int CompanyId { get; set; }
        public string CurrencyCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>()
                .ForMember(a => a.BranchName, a => a.MapFrom(p => p.Branch.BranchName))
                .ForMember(a => a.UOM, a => a.MapFrom(p => p.UnitOfMeasure.UOM))
                .ForMember(a => a.CurrencyCode, a => a.MapFrom(p => p.Currency.CurrencyCode));
        }
    }
}
