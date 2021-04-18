using Autofac;
using AutoMapper;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public static class MappingSetup
    {
        public static void SetupMapping(this ContainerBuilder containerBuilder)
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductProfile>();
                x.AddProfile<ProductReviewProfile>();
            });

            var mapper = config.CreateMapper();

            containerBuilder.RegisterInstance(mapper)
                .As<IMapper>()
                .SingleInstance();
        }
    }
}