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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.RoleId).HasMaxLength(10).IsRequired();

            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Orders)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UseCases)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
