using BuyMe.Application.Product.Queries;
using MediatR;
using System;
using System.Collections.Generic;

namespace BuyMe.Application.Product.Commonds
{
    public class CreateEditProductCommond : IRequest<int>
    {
        public CreateEditProductCommond()
        {
            ProductImages ??= new List<string>();
            ProductDescriptions = new List<ProductDescriptionDto>();
        }

        public int? ProductId { get; set; }
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
        public int? CompanyId { get; set; }
        public string CurrencyCode { get; set; }
        public bool AllowMarketing { get; set; }
        public List<string> ProductImages { get; set; }
        public IList<ProductDescriptionDto> ProductDescriptions { get; set; }
    }
}