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
    public class BaverageConfiguration : IEntityTypeConfiguration<Baverage>
    {
        public void Configure(EntityTypeBuilder<Baverage> builder)
        {
            builder.Property(x => x.BaverageName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CategoryId).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.BaverageName);

            builder.HasMany(x => x.BaverageIngredients)
                    .WithOne(x => x.Baverage)
                    .HasForeignKey(x => x.BavarageId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
