using Autofac;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.Services.Coupon;
using Mantasflowers.Services.Services.Order;
using Mantasflowers.Services.Services.Payment;
using Mantasflowers.Services.Services.Product;
using Mantasflowers.Services.Services.Review;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Setup.Mapping;
using Stripe.Checkout;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.SetupMapping();

            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .InstancePerDependency();

            builder.RegisterType<ProductReviewService>()
                .As<IProductReviewService>()
                .InstancePerDependency();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerDependency();

            builder.RegisterType<FirebaseService>()
                .InstancePerDependency();

            builder.RegisterType<FirebaseConfig>() // TODO: get rid of this (read MSDN docs on httpClients configuration)
                .SingleInstance();

            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .InstancePerDependency();

            builder.RegisterType<PaymentService>()
                .As<IPaymentService>()
                .InstancePerDependency();

            builder.RegisterType<SessionService>()
                .InstancePerDependency();

            builder.RegisterType<Stripe.CouponService>()
                .InstancePerDependency();

            builder.RegisterType<Stripe.PromotionCodeService>()
                .InstancePerDependency();

            builder.RegisterType<CouponService>()
                .As<ICouponService>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}