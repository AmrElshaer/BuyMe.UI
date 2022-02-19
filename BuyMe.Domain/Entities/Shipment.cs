using System;

namespace BuyMe.Domain.Entities
{
    public class Shipment
    {
        public long ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public long? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int? ShipmentTypeId { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public bool IsFullShipment { get; set; } = true;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Remarks { get; set; }
    }
}