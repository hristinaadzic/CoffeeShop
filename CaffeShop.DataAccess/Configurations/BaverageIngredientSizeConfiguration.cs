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
    public class BaverageIngredientSizeConfiguration : IEntityTypeConfiguration<BaverageIngredientSize>
    {
        public void Configure(EntityTypeBuilder<BaverageIngredientSize> builder)
        {
            builder.HasKey(x => new { x.BaverageIngredientId, x.SizeId });

            builder.Property(x => x.IngredientQuantity).HasMaxLength(10).IsRequired();

            //builder.HasMany(x => x.Prices)
            //        .WithOne(x => x.BaverageIngredientSize)
            //        .HasForeignKey(x => x.BaverageSizeId)
            //        .OnDelete(DeleteBehavior.Restrict);
                    
        }
    }
}
