using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DataAccess.Configurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(x => x.BavIngSizeId).HasMaxLength(10).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Quantity).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Price).HasMaxLength(10).IsRequired();
            builder.Property(x => x.OrderId).HasMaxLength(10).IsRequired();
        }
    }
}
