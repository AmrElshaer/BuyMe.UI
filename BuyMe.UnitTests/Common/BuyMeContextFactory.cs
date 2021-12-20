﻿using BuyMe.Application.Common.Interfaces;
using BuyMe.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UnitTests.Common
{
    public class BuyMeContextFactory
    {
        public static BuyMeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BuyMeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new BuyMeDbContext(options,new Mock<ITenantService>().Object,new Mock<ICurrentUserService>().Object);
            context.Database.EnsureCreated();
            context.Companies.Add(new Domain.Entities.Company{ Name="BuyMe"});
            context.SaveChanges();
            return context;
        }
        public static void Destroy(BuyMeDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
