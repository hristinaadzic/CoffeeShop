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
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.IngredientName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Quantity).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.IngredientName);

            builder.HasMany(x => x.BavarageIngredients)
                    .WithOne(x => x.Ingredient)
                    .HasForeignKey(x => x.IngredientId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
