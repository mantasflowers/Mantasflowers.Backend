using System;
using System.Linq.Expressions;
using Mantasflowers.Domain.Entities;
using Mantasflowers.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mantasflowers.Persistence
{
    public sealed class DatabaseContext : DbContext
    {
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
            modelBuilder.Entity<Product>(
                e =>
                {
                    e.Property(p => p.Name)
                        .HasMaxLength(100)
                        .IsRequired();
                    e.Property(p => p.Price)
                        .HasColumnType("decimal(18,4)")
                        .IsRequired();
                    e.Property(p => p.Category)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<ProductCategory>(),
                            StringProviderToEnumModel<ProductCategory>()
                        );
                    e.Property(p => p.Description)
                        .HasMaxLength(300);
                    e.Property(p => p.Status)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<ProductStatus>(),
                            StringProviderToEnumModel<ProductStatus>()
                        );
                    e.Property(p => p.PictureName)
                        .HasMaxLength(260);
                }
            );

            modelBuilder.Entity<ProductReview>(
                e =>
                {
                    e.HasIndex(p => new { p.ProductId, p.UserId })
                        .IsUnique();
                }
            );

            modelBuilder.Entity<User>(
                e =>
                {
                    e.Property(p => p.FirstName)
                        .HasMaxLength(200)
                        .IsRequired();
                    e.Property(p => p.LastName)
                    
                        .HasMaxLength(200)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<UserAddress>(
                e =>
                {
                    e.Property(p => p.Country)
                        .HasMaxLength(100)
                        .IsRequired();
                    e.Property(p => p.City)
                        .HasMaxLength(100)
                        .IsRequired();
                    e.Property(p => p.Street)
                        .HasMaxLength(100)
                        .IsRequired();
                    e.Property(p => p.Zipcode)
                        .HasMaxLength(20)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<UserContactInfo>(
                e =>
                {
                    e.Property(p => p.Email)
                        .HasMaxLength(320)
                        .IsRequired();
                    e.Property(p => p.Phone)
                        .HasMaxLength(20)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<Order>(
                e =>
                {
                    // TODO: is it possible to enforce Order(user_id, status: Draft) here ?
                    // i.e. enforce that one user has <= 1 Order of type Draft at any given time

                    e.Property(p => p.Status)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<OrderStatus>(),
                            StringProviderToEnumModel<OrderStatus>()
                        );
                    e.Property(p => p.Type)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<OrderType>(),
                            StringProviderToEnumModel<OrderType>()
                        );
                    e.Property(p => p.TemporaryPasswordHash)
                        .HasMaxLength(300)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<OrderItem>(
                e =>
                {
                    e.HasIndex(p => new { p.OrderId, p.ProductId })
                        .IsUnique();
                }
            );


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

        private static Expression<Func<TEnumModel, string>> EnumModelToStringProvider<TEnumModel>()
            where TEnumModel : struct, IConvertible
        {
            return (TEnumModel x) => x.ToString();
        }

        private static Expression<Func<string, TEnumModel>> StringProviderToEnumModel<TEnumModel>()
            where TEnumModel : struct, IConvertible
        {
            return (string x) => Enum.Parse<TEnumModel>(x);
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
                    Category = ProductCategory.FLOWER,
                    Description = "veri priti flauver",
                    Status = ProductStatus.AVAILABLE,
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
                    Status = OrderStatus.DRAFT,
                    ShipmentId = shipmentId1,
                    PaymentId = paymentId1,
                    Type = OrderType.REGULAR,
                    TemporaryPasswordHash = "eyy123"
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
