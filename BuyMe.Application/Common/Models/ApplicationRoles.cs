using System.Collections.Generic;
using System.Linq;

namespace BuyMe.Application.Common.Models
{
    public class ApplicationRoles
    {
        public const string Product = "Product";
        public const string Warehouse = "Warehouse";
        public const string CustomerType = "CustomerType";
        public const string Customer = "Customer";
        public const string SalesType = "SalesType";
        public const string SalesOrder = "SalesOrder";
        public const string Category = "Category";
        public const string UnitOfMeasure = "UnitOfMeasure";
        public const string Currency = "Currency";
        public const string Branch = "Branch";
        public const string Template = "Template";
        public const string Settings = "Settings";
        public const string User = "User";
        public const string ChangeRole = "ChangeRole";
        public const string ShipmentType = "ShipmentType";
        public const string Shipment = "Shipment";
        public const string InvoiceType = "InvoiceType";
        public const string Invoice = "Invoice";
        public const string PaymentType = "PaymentType";
        public const string PaymentReceive = "PaymentReceive";
        public const string VendorType = "VendorType";
        public const string Vendor = "Vendor";

        public static IEnumerable<string> GetRoles()
        {
            var roles = typeof(ApplicationRoles).GetFields().Select(a => a.Name);
            return roles;
        }
    }
}