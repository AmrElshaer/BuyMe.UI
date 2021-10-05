using BuyMe.Application.Category.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace BuyMe.Application.Category.Commonds
{
    public class CreateEditCategoryCommond : IRequest<int>
    {
        public CreateEditCategoryCommond()
        {
            this.CategoryDescriptions = new List<CategoryDescriptionDto>();
        }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public IList<CategoryDescriptionDto> CategoryDescriptions { get; set; }
        public void RefreshDescriptionCategorys()
        {
            if (string.IsNullOrEmpty(this.Description))
                return;
            var descs = this.Description.Split(',').ToList();
            // remove if no longer exist
            CategoryDescriptions.ToList().ForEach(a => { if (!descs.Contains(a.Description)) { this.CategoryDescriptions.Remove(a); } });
            // add if it new description
            descs.ForEach(a => {
                if (!this.CategoryDescriptions.Select(a => a.Description).Contains(a))
                { this.CategoryDescriptions.Add(new CategoryDescriptionDto() {  Description = a }); }
            });

        }
    }
}