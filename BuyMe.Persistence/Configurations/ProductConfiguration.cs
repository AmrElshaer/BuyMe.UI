using BuyMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.DefaultBuyingPrice).HasColumnType("decimal(18,4)");
            builder.Property(a => a.DefaultSellingPrice).HasColumnType("decimal(18,4)");
        }
    }
}
