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
    public class BaverageIngredientConfiguration : IEntityTypeConfiguration<BaverageIngredient>
    {
        public void Configure(EntityTypeBuilder<BaverageIngredient> builder)
        {
            //builder.HasKey(x => new { x.BavarageId, x.IngredientId });

            builder.HasMany(x => x.BaverageIngredientSizes)
                    .WithOne(x => x.BaverageIngredient)
                    .HasForeignKey(x => x.BaverageIngredientId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
