using Autofac;
using AutoMapper;
using Mantasflowers.WebApi.Setup.Mapping.ServiceAgentMappings;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public static class MappingSetup
    {
        public static void SetupMapping(this ContainerBuilder containerBuilder)
        {
            var config = new MapperConfiguration(x =>
            {
                /* Service mappings */
                x.AddProfile<ProductProfile>();
                x.AddProfile<ProductReviewProfile>();
                x.AddProfile<UserProfile>();
                x.AddProfile<OrderProfile>();
                x.AddProfile<PaymentProfile>();

                /* Service agent mappings */
                x.AddProfile<FirebaseServiceAgentProfile>();
            });

            var mapper = config.CreateMapper();

            containerBuilder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();
        }
    }
}