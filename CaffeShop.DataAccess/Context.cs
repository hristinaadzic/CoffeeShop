using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options = null) : base(options)
        {

        }
        ////public Context(DbContextOptions options) : base(options)
        ////{

        ////}

        public Context() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            base.OnModelCreating(modelBuilder);
        }

        public IApplicationUser User { get; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MUTLEBOJ\SQLEXPRESS;Initial Catalog=coffeeshop2;Integrated Security=True");
        //}

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Baverage> Baverages { get; set; }
        public DbSet<BaverageIngredient> BaverageIngredients { get; set; }
        public DbSet<BaverageSize> BaverageSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
