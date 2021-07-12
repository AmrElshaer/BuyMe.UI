using MediatR;

namespace BuyMe.Application.UnitOfMeasure.Commonds
{
    public class CreateEditUnitOfMeasureCommond : IRequest<int>
    {
        public int? Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}