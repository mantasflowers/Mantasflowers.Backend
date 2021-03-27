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

            // TODO: remove data seed when no longer needed
            Seed(modelBuilder);

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

        private static void Seed(ModelBuilder modelBuilder)
        {
            var productId1 = Guid.NewGuid();
            var userId1 = Guid.NewGuid();
            var userAddress1 = Guid.NewGuid();
            var userContactInfo1 = Guid.NewGuid();
            var paymentId1 = Guid.NewGuid();
            var shipmentId1 = Guid.NewGuid();
            var orderId1 = Guid.NewGuid();

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = productId1,
                    Name = "my rose",
                    Price = 1.99m,
                    Category = Domain.Enums.ProductCategory.FLOWER,
                    Description = "veri priti flauver",
                    Status = Domain.Enums.ProductStatus.AVAILABLE,
                    LeftInStock = 1000
                }
            );
            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress
                {
                    Id = userAddress1,
                    Country = "LT",
                    City = "Vilnius",
                    Street = "Autism street",
                    Zipcode = "LT-12345"
                }
            );
            modelBuilder.Entity<UserContactInfo>().HasData(
                new UserContactInfo
                {
                    Id = userContactInfo1,
                    Email = "theforcebewithyou@coruscant.com",
                    Phone = "861234567"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    FirstName = "Obi-Wan",
                    LastName = "Kenobi",
                    IsRegistered = true,
                    AddressId = userAddress1,
                    ContactsId = userContactInfo1
                }
            );
            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId1,
                    UserId = userId1
                }
            );
            modelBuilder.Entity<Shipment>().HasData(
                new Shipment
                {
                    Id = shipmentId1
                }
            );
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = paymentId1
                }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = orderId1,
                    UserId = userId1,
                    Status = Domain.Enums.OrderStatus.DRAFT,
                    ShipmentId = shipmentId1,
                    PaymentId = paymentId1,
                }
            );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId1,
                    ProductId = productId1,
                    Quantity = 666
                }
            );
        }
    }
}
