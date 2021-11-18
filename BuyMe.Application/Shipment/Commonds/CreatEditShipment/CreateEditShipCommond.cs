using BuyMe.Domain.Entities;
using MediatR;
using System;

namespace BuyMe.Application.Shipment.Commonds
{
    public class CreateEditShipCommond : IRequest<long>
    {
        public long? ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public long SalesOrderId { get; set; }
        public DateTimeOffset ShipmentDate { get; set; }
        public int ShipmentTypeId { get; set; }
        public int WarehouseId { get; set; }
        public int CompanyId { get; set; }
        public string Remarks { get; set; }
        public bool IsFullShipment { get; set; } = true;
    }
}