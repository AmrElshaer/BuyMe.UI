using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class Product
    {
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
    }
}
