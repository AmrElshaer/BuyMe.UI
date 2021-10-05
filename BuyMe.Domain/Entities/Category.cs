using System.Collections.Generic;
using System.Linq;

namespace BuyMe.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            CategoryDescriptions = new HashSet<CategoryDescription>();
        }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryDescription> CategoryDescriptions { get; set; }
        public void UPSertCategorydesc(string descr)
        {
            if (string.IsNullOrEmpty(descr))
                return;
            var descs = descr.Split(',').ToList();
            // remove if no longer exist
            CategoryDescriptions.ToList().ForEach(a => { if (!descs.Contains(a.Description)) {  this.CategoryDescriptions.Remove(a); } });
            // add if it new description
            descs.ForEach(a=> { if (!this.CategoryDescriptions.Select(a=>a.Description).Contains(a)) 
                { this.CategoryDescriptions.Add(new CategoryDescription() {CompanyId=this.CompanyId,Description=a }); } });
            
        }
    }
}