using Autofac;
using Mantasflowers.Services.FirebaseService;
using Mantasflowers.Services.Services.Coupon;
using Mantasflowers.Services.Services.Order;
using Mantasflowers.Services.Services.Payment;
using Autofac.Extras.DynamicProxy;
using Mantasflowers.Services.Services.Product;
using Mantasflowers.Services.Services.User;
using Mantasflowers.WebApi.Setup.DI.Interceptors;
using Mantasflowers.WebApi.Setup.Mapping;
using Stripe.Checkout;
using Mantasflowers.Services.Services.HashMap;
using Mantasflowers.Services.Services.Shipment;
using Mantasflowers.Services.Services.Email;

namespace Mantasflowers.WebApi.Setup.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.SetupMapping();

            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            // builder.RegisterType<ProductReviewService>()
            //     .As<IProductReviewService>()
            //     .EnableInterfaceInterceptors()
            //     .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
            //     .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<FirebaseService>()
                .InstancePerDependency();

            builder.RegisterType<FirebaseConfig>() // TODO: get rid of this (read MSDN docs on httpClients configuration)
                .SingleInstance();

            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<PaymentService>()
                .As<IPaymentService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<SessionService>()
                .InstancePerDependency();

            builder.RegisterType<Stripe.CouponService>()
                .InstancePerDependency();

            builder.RegisterType<Stripe.PromotionCodeService>()
                .InstancePerDependency();

            builder.RegisterType<Stripe.CustomerService>()
                .InstancePerDependency();

            builder.RegisterType<CouponService>()
                .As<ICouponService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<HashMapService>()
                .As<IHashMapService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<ShipmentService>()
                .As<IShipmentService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailService>()
                .As<IEmailService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}