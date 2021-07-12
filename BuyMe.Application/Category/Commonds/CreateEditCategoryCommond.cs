using MediatR;

namespace BuyMe.Application.Category.Commonds
{
    public class CreateEditCategoryCommond : IRequest<int>
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}