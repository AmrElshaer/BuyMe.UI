using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Domain.Entities;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UnitTests.Common
{
    public class BuyMeContextFactory
    {
        public static BuyMeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BuyMeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new BuyMeDbContext(options, new Mock<ITenantService>().Object, new Mock<ICurrentUserService>().Object);
            context.Database.EnsureCreated();
            context.Companies.AddRange(new Company { Name = "CompanyOne" }, new Company() { Name = "CompanyTwo" });
            SeedCustomFieldAndData(context);
            context.SaveChanges();
            return context;
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