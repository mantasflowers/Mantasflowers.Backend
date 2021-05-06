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

        public DbSet<ProductInfo> ProductInfo { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<UserContactInfo> UserContactInfo { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<OrderAddress> OrderAddresses { get; set; }

        public DbSet<OrderContactInfo> OrderContactInfo { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<UserOrder> UserOrders { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

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
                    e.Property(p => p.Category)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<ProductCategory>(),
                            StringProviderToEnumModel<ProductCategory>()
                        );
                    e.Property(p => p.Price)
                        .HasColumnType("decimal(18,4)");
                    e.Property(p => p.DiscountPercent)
                        .HasColumnType("decimal(18,4)");
                    e.Property(p => p.ShortDescription)
                        .HasMaxLength(50);
                    e.Property(p => p.ThumbnailPictureUrl)
                        .HasMaxLength(260);
                }
            );

            modelBuilder.Entity<ProductInfo>(
                e =>
                {
                    e.Property(p => p.Description)
                        .HasMaxLength(300);
                    e.Property(p => p.PictureUrl)
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
                        .HasMaxLength(200);
                    e.Property(p => p.LastName)
                        .HasMaxLength(200);
                    e.HasIndex(p => p.Uid)
                        .IsUnique();
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
                    e.HasIndex(p => p.UserId)
                        .IsUnique();
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
                    e.HasIndex(p => p.UserId)
                        .IsUnique();
                }
            );

            modelBuilder.Entity<Order>(
                e =>
                {
                    e.Property(p => p.Status)
                        .HasMaxLength(50)
                        .HasConversion(
                            EnumModelToStringProvider<OrderStatus>(),
                            StringProviderToEnumModel<OrderStatus>()
                        );
                    e.Property(p => p.TemporaryPasswordHash)
                        .HasMaxLength(300)
                        .IsRequired();
                    e.Property(p => p.DiscountPrice)
                        .HasColumnType("decimal(18,4)");
                    e.Property(p => p.Message)
                        .HasMaxLength(500);
                }
            );

            modelBuilder.Entity<OrderAddress>(
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
                    e.HasIndex(p => p.OrderId)
                        .IsUnique();
                }
            );

            modelBuilder.Entity<OrderContactInfo>(
                e =>
                {
                    e.Property(p => p.Email)
                        .HasMaxLength(320);
                        // .IsRequired();
                    e.Property(p => p.Phone)
                        .HasMaxLength(20)
                        .IsRequired();
                    e.HasIndex(p => p.OrderId)
                        .IsUnique();
                }
            );

            modelBuilder.Entity<OrderItem>(
                e =>
                {
                    e.HasIndex(p => new { p.OrderId, p.ProductId })
                        .IsUnique();
                    e.Property(p => p.UnitPrice)
                        .HasColumnType("decimal(18,4)");
                }
            );

            modelBuilder.Entity<UserOrder>(
                e =>
                {
                    e.HasIndex(p => new { p.OrderId, p.UserId })
                        .IsUnique();
                }
            );

            modelBuilder.Entity<Coupon>(
                e =>
                {
                    e.Property(p => p.Name)
                        .HasMaxLength(30)
                        .IsRequired();
                    e.Property(p => p.DiscountPrice)
                        .HasColumnType("decimal(18,4)");
                    e.Property(p => p.OrderOverPrice)
                        .HasColumnType("decimal(18,4)");
                }
            );

            modelBuilder.Entity<Feedback>(
                e =>
                {
                    e.Property(p => p.Name)
                        .HasMaxLength(200)
                        .IsRequired();
                    e.Property(p => p.Email)
                        .HasMaxLength(320)
                        .IsRequired();
                    e.Property(p => p.Text)
                        .HasMaxLength(500)
                        .IsRequired();
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
            string pictureUrl = "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg";

            var productInfoId1 = Guid.NewGuid();
            var productInfoId2 = Guid.NewGuid();
            var productInfoId3 = Guid.NewGuid();
            var productInfoId4 = Guid.NewGuid();
            var productInfoId5 = Guid.NewGuid();
            var productInfoId6 = Guid.NewGuid();
            var productInfoId7 = Guid.NewGuid();
            var productInfoId8 = Guid.NewGuid();
            var productInfoId9 = Guid.NewGuid();
            var productInfoId10 = Guid.NewGuid();
            var productId1 = Guid.NewGuid();
            var productId2 = Guid.NewGuid();
            var productId3 = Guid.NewGuid();
            var productId4 = Guid.NewGuid();
            var productId5 = Guid.NewGuid();
            var productId6 = Guid.NewGuid();
            var productId7 = Guid.NewGuid();
            var productId8 = Guid.NewGuid();
            var productId9 = Guid.NewGuid();
            var productId10 = Guid.NewGuid();
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userAddress1 = Guid.NewGuid();
            var userAddress2 = Guid.NewGuid();
            var userContactInfo1 = Guid.NewGuid();
            var userContactInfo2 = Guid.NewGuid();
            var paymentId1 = Guid.NewGuid();
            var shipmentId1 = Guid.NewGuid();
            var orderAddressId1 = Guid.NewGuid();
            var orderContactInfoId1 = Guid.NewGuid();
            var orderId1 = Guid.NewGuid();
            var userOrderId1 = Guid.NewGuid();
            var couponId1 = Guid.NewGuid();
            var feedbackId1 = Guid.NewGuid();

            modelBuilder.Entity<ProductInfo>().HasData(
                new ProductInfo
                {
                    Id = productInfoId1,
                    Description = "yes, a veri pritti flauever. plis buy",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId2,
                    Description = "best flower in the ninja village",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId3,
                    Description = "description 3",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId4,
                    Description = "description 4",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId5,
                    Description = "description 5",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId6,
                    Description = "description 6",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId7,
                    Description = "description 7",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId8,
                    Description = "description 8",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId9,
                    Description = "description 9",
                    PictureUrl = pictureUrl
                },
                new ProductInfo
                {
                    Id = productInfoId10,
                    Description = "description 10",
                    PictureUrl = pictureUrl
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = productId1,
                    Name = "my rose",
                    Category = ProductCategory.FLOWER,
                    ShortDescription = "veri priti flauver",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 1.99m,
                    LeftInStock = 1000,
                    DiscountPercent = null,
                    ProductInfoId = productInfoId1
                },
                new Product
                {
                    Id = productId2,
                    Name = "konoha leaf",
                    Category = ProductCategory.FLOWER,
                    ShortDescription = "its a real flower",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 2.99m,
                    LeftInStock = 123,
                    DiscountPercent = 0.2m,
                    ProductInfoId = productInfoId2,
                },
                new Product
                {
                    Id = productId3,
                    Name = "bone",
                    Category = ProductCategory.BOUQUET,
                    ShortDescription = "Big bone with extra calcium",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 5.99m,
                    LeftInStock = 4,
                    DiscountPercent = 0.0m,
                    ProductInfoId = productInfoId3,
                },
                new Product
                {
                    Id = productId4,
                    Name = "name 4",
                    Category = ProductCategory.FLOWER,
                    ShortDescription = "short description 4",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 2.49m,
                    LeftInStock = 400,
                    DiscountPercent = 0.15m,
                    ProductInfoId = productInfoId4,
                },
                new Product
                {
                    Id = productId5,
                    Name = "name 5",
                    Category = ProductCategory.BOUQUET,
                    ShortDescription = "short description 5",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 11.29m,
                    LeftInStock = 15,
                    DiscountPercent = 0.0m,
                    ProductInfoId = productInfoId5,
                },
                new Product
                {
                    Id = productId6,
                    Name = "name 6",
                    Category = ProductCategory.BOUQUET,
                    ShortDescription = "short description 6",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 1.29m,
                    LeftInStock = 153,
                    DiscountPercent = 0.40m,
                    ProductInfoId = productInfoId6,
                },
                new Product
                {
                    Id = productId7,
                    Name = "name 7",
                    Category = ProductCategory.FLOWER,
                    ShortDescription = "short description 7",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 0.59m,
                    LeftInStock = 4321,
                    DiscountPercent = 0.10m,
                    ProductInfoId = productInfoId7,
                },
                new Product
                {
                    Id = productId8,
                    Name = "name 8",
                    Category = ProductCategory.BOUQUET,
                    ShortDescription = "short description 8",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 7.19m,
                    LeftInStock = 125,
                    DiscountPercent = 0.3m,
                    ProductInfoId = productInfoId8,
                },
                new Product
                {
                    Id = productId9,
                    Name = "name 9",
                    Category = ProductCategory.FLOWER,
                    ShortDescription = "short description 9",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 2.49m,
                    LeftInStock = 1233,
                    DiscountPercent = 0.0m,
                    ProductInfoId = productInfoId9,
                },
                new Product
                {
                    Id = productId10,
                    Name = "name 10",
                    Category = ProductCategory.BOUQUET,
                    ShortDescription = "short description 10",
                    ThumbnailPictureUrl = pictureUrl,
                    Price = 7.99m,
                    LeftInStock = 34,
                    DiscountPercent = 0.0m,
                    ProductInfoId = productInfoId10,
                }
            );
            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress
                {
                    Id = userAddress1,
                    Country = "LT",
                    City = "Vilnius",
                    Street = "Autism street",
                    Zipcode = "LT-12345",
                    UserId = userId1,
                },
                new UserAddress
                {
                    Id = userAddress2,
                    Country = "LT",
                    City = "Kaunas",
                    Street = "Kaimas street",
                    Zipcode = "LT-54321",
                    UserId = userId2
                }
            );
            modelBuilder.Entity<UserContactInfo>().HasData(
                new UserContactInfo
                {
                    Id = userContactInfo1,
                    Email = "theforcebewithyou@coruscant.com",
                    Phone = "+37061234567",
                    UserId = userId1
                },
                new UserContactInfo
                {
                    Id = userContactInfo2,
                    Email = "asdiasdioas@asfiasifa.com",
                    Phone = "+37069263957",
                    UserId = userId2
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId1,
                    Uid = "o2DfmuP9NRcw19bDbvSrg6lpavF2",
                    FirstName = "Obi-Wan",
                    LastName = "Kenobi",
                },
                new User
                {
                    Id = userId2,
                    Uid = "ikpWhF3UzsXFAue98r9pBA7RwGs1",
                    FirstName = "Luke",
                    LastName = "Skywalker",
                }
            );
            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview
                {
                    Id = Guid.NewGuid(),
                    ReviewScore = 3.5,
                    ProductId = productId1,
                    UserId = userId1
                },
                new ProductReview
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId2,
                    ReviewScore = 10.0,
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
            modelBuilder.Entity<OrderAddress>().HasData(
                new OrderAddress
                {
                    Id = orderAddressId1,
                    Country = "LT",
                    City = "Vilnius",
                    Street = "Autism street",
                    Zipcode = "LT-12345",
                    OrderId = orderId1
                }
            );
            modelBuilder.Entity<OrderContactInfo>().HasData(
                new OrderContactInfo
                {
                    Id = orderContactInfoId1,
                    Email = "theforcebewithyou@coruscant.com",
                    Phone = "861234567",
                    OrderId = orderId1
                }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = orderId1,
                    Status = OrderStatus.UNPAID,
                    ShipmentId = shipmentId1,
                    PaymentId = paymentId1,
                    TemporaryPasswordHash = "eyy123",
                    OrderNumber = 123,
                    DiscountPrice = null,
                    Message = "i feel like a flower"
                }
            );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId1,
                    ProductId = productId1,
                    Quantity = 666,
                    UnitPrice = 1.59m
                }
            );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId1,
                    ProductId = productId3,
                    Quantity = 8008,
                    UnitPrice = 1.58m
                }
            );
            modelBuilder.Entity<UserOrder>().HasData(
                new UserOrder
                {
                    Id = userOrderId1,
                    OrderId = orderId1,
                    UserId = userId1
                }
            );
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = couponId1,
                    Name = "PSK666",
                    BeginDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(90),
                    DiscountPrice = 10.0m,
                    OrderOverPrice = 15.0m
                }
            );
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = feedbackId1,
                    Name = "Hannibal Lecter",
                    Email = "Lambs street 13",
                    Text = "Tasty flowers"
                }
            );
        }
    }
}
