using System;
using Mantasflowers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mantasflowers.Persistence
{
    public sealed class DatabaseContext : DbContext
    {
        // public DatabaseContext() { } // TODO: might not be needed (dotnet-ef dbcontext info)

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            ChangeTracker.Tracked += OnEntityTrackedHandler;
            ChangeTracker.StateChanged += OnEntityStateChangedHandler;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<UserContactInfo> UserContactInfo { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        // TODO: future TODO and aren't used by anything
        // public DbSet<Supplier> Suppliers { get; set; }
        // public DbSet<Warehousing> Warehousing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Describe entity constraints here
            // modelBuilder.Entity<OrderItem>(
            //     e =>
            //     {
            //        e.HasOne(p => p.User)
            //     }
            // );

            // modelBuilder.Entity<ProductReview>(
            //     e =>
            //     {
            //         e.HasOne
            //     }
            // );


            base.OnModelCreating(modelBuilder);
        }

        private static void OnEntityTrackedHandler(object sender, EntityTrackedEventArgs args)
        {
            if (args.Entry.Entity is BaseEntity entity && args.Entry.State == EntityState.Added && !args.FromQuery)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
        }

        private static void OnEntityStateChangedHandler(object sender, EntityStateChangedEventArgs args)
        {
            if (args.Entry.Entity is BaseEntity entity && args.NewState == EntityState.Modified)
            {
                entity.UpdatedOn = DateTime.UtcNow;
            }
        }
    }
}
