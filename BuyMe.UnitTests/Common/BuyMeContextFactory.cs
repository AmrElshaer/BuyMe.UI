using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Domain.Entities;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace BuyMe.UnitTests.Common
{
    public class BuyMeContextFactory
    {
        public static BuyMeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BuyMeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new BuyMeDbContext(options, new Mock<ITenantService>().Object, new Mock<ICurrentUserService>().Object);
            context.Database.EnsureCreated();
            SeedCompanyData(context);
            SeedShipmentData(context);
            SeedInvoiceTypeData(context);
            SeedInvoiceData(context);
            SeedCustomFieldAndData(context);
            SeedPaymentTypeData(context);
            SeedPaymentReceiveData(context);
            context.SaveChanges();
            return context;
        }

        private static void SeedPaymentTypeData(BuyMeDbContext context)
        {
            context.PaymentTypes.AddRange(new PaymentType { PaymentTypeName = "Pay4", Description = "PayDes" },
                           new PaymentType { PaymentTypeName = "Pay35", Description = "PayDes3" });
        }

        private static void SeedInvoiceTypeData(BuyMeDbContext context)
        {
            context.InvoiceTypes.AddRange(new InvoiceType { InvoiceTypeName = "Inv34", Description = "InvDes" },
                            new InvoiceType { InvoiceTypeName = "Inv35", Description = "InvDes3" });
        }

        private static void SeedCompanyData(BuyMeDbContext context)
        {
            context.Companies.AddRange(new Company { Name = "CompanyOne" }, new Company() { Name = "CompanyTwo" });
        }

        private static void SeedInvoiceData(BuyMeDbContext context)
        {
            
            context.Invoices.AddRange(new Invoice
            {
                InvoiceName = "00001#INV",
                ShipmentId = 1,
                InvoiceTypeId = 1
            },
            new Invoice()
            {
                InvoiceName = "00002#INV",
                ShipmentId = 2,
                InvoiceTypeId = 2
            }, new Invoice()
            {
                InvoiceName = "00003#INV",
                ShipmentId = 1,
                InvoiceTypeId = 1
            }
            );
        }
        private static void SeedPaymentReceiveData(BuyMeDbContext context)
        {

            context.PaymentReceives.AddRange(new PaymentReceive
            {
                PaymentReceiveName = "00001#PAYRCV",
                PaymentTypeId = 1,
                InvoiceId = 1
            },
            new PaymentReceive()
            {
                PaymentReceiveName = "00002#PAYRCV",
                PaymentTypeId = 2,
                InvoiceId = 2
            }, new PaymentReceive()
            {
                PaymentReceiveName = "00003#PAYRCV",
                PaymentTypeId = 1,
                InvoiceId = 1
            }
            );
        }
        private static void SeedShipmentData(BuyMeDbContext context)
        {
            context.Shipments.AddRange(new Shipment()
            {
                CompanyId = 1,
                ShipmentName = "00001#ship"
            }, new Shipment()
            {
                CompanyId = 1,
                ShipmentName = "00002#ship"
            });
        }

        private static void SeedCustomFieldAndData(BuyMeDbContext context)
        {
            context.CustomFields.AddRange(new CustomField()
            {
                FieldName = "CustomNameOne",
                FieldType = "Text",
                Category = CustomCategoryModel.Product,
                CompanyId = 1
            }, new CustomField()
            {
                FieldName = "CustomNameTwo",
                FieldType = "Text",
                Category = CustomCategoryModel.Product,
                CompanyId = 1
            }, new CustomField()
            {
                FieldName = "CustomNameThree",
                FieldType = "Text",
                Category = CustomCategoryModel.Product,
                CompanyId = 1
            });
            context.CustomFieldDatas.AddRange(
                new CustomFieldData()
                {
                    RefranceId = 1,
                    Category = CustomCategoryModel.Product,
                    Value = "[{'FieldName':'CustomNameOne','FieldValue':'#b03636'}]",
                    CompanyId = 1
                },
            new CustomFieldData()
            {
                RefranceId = 2,
                Category = CustomCategoryModel.Product,
                Value = "[{'FieldName':'CustomNameOne','FieldValue':'#b09636'}]",
                CompanyId = 1
            }
            , new CustomFieldData()
            {
                RefranceId = 3,
                Category = CustomCategoryModel.Product,
                Value = "[{'FieldName':'CustomNameOne','FieldValue':'#b09636'},{'FieldName':'CustomNameTwo','FieldValue':'#b09636'}]",
                CompanyId = 1
            });
        }

        public static void Destroy(BuyMeDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}