﻿using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DataAccess.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasMany(x => x.BaveragesSizes)
                .WithOne(x => x.Size)
                .HasForeignKey(x => x.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
