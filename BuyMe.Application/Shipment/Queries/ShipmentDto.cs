using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Application.ShipmentType.Queries;
using BuyMe.Application.WarehouseINV.Queries;
using BuyMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Shipment.Queries
{
    public class ShipmentDto : IMapFrom
    {
        public long ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public long? SalesOrderId { get; set; }
        public SalesOrderDto SalesOrder { get; set; }
        public string SalesOrderName { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int? ShipmentTypeId { get; set; }
        public ShipmentTypeDto ShipmentType { get; set; }
        public int? WarehouseId { get; set; }
        public WarhouseDto Warehouse { get; set; }
        public string WarehouseName { get; set; }
        public bool IsFullShipment { get; set; } = true;
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public string Remarks { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Shipment, ShipmentDto>()
                .ForMember(a => a.SalesOrderName, a => a.MapFrom(p => p.SalesOrder.SalesOrderName))
                .ForMember(a => a.WarehouseName, a => a.MapFrom(p => p.Warehouse.WarehouseName));

        }
    }
}
