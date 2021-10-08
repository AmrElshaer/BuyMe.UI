using System;
using System.Collections.Generic;
using System.Linq;

namespace BuyMe.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImages>();
            ProductDescriptions = new HashSet<ProductDescription>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Barcode { get; set; }
        public Decimal? DefaultBuyingPrice { get; set; }
        public Decimal? DefaultSellingPrice { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public string Description { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public bool AllowMarketing { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<ProductDescription> ProductDescriptions { get; set; }

        public void UpSertProductDescs(IList<ProductDescription> productDescriptions)
        {
            productDescriptions.ToList().ForEach(a =>
            {
                if (a.Id == 0)
                {
                    this.ProductDescriptions.Add(a);
                }
                else
                {
                    var proDesc = this.ProductDescriptions.FirstOrDefault(p => p.Id == a.Id);
                    proDesc.Description = a.Description;
                }

            });
        }
    }
}