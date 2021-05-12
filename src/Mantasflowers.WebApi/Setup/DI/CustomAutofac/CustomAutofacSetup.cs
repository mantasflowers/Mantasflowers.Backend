using System;
using System.IO;
using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Newtonsoft.Json;

namespace Mantasflowers.WebApi.Setup.DI.CustomAutofac
{
    public static class CustomAutofacSetup
    {
        public static void LoadCustomAutofacJson(this ContainerBuilder builder, string filePath)
        {
            var configuration = 
                JsonConvert.DeserializeObject<CustomAutofacRegistrations>(File.ReadAllText(filePath));

            foreach (var component in configuration.Components)
            {
                IRegistrationBuilder<object, object, object> registration;

                var type = Type.GetType(component.Type, true);

                if (type.IsGenericTypeDefinition)
                {
                    registration = builder.RegisterGeneric(type);
                }
                else
                {
                    registration = builder.RegisterType(type);
                }

                if (component.Interfaces?.Count > 0)
                {
                    foreach (var interf in component.Interfaces)
                    {
                        var interfType = Type.GetType(interf.Type, true);

                        registration.As(interfType);
                    }
                }

                if (component.Interceptors?.Count > 0 && component.Interfaces?.Count == 0)
                {
                    throw new InvalidOperationException("Cannot register interface interceptors when no interfaces were registered");
                }

                if (component.Interceptors?.Count > 0)
                {
                    registration.EnableInterfaceInterceptors();

                    foreach (var interceptor in component.Interceptors)
                    {
                        var interceptorType = Type.GetType(interceptor.Type);

                        registration.InterceptedBy(interceptorType);
                    }
                }

                PickComponentLifetime(registration, component.Scope);
            }
        }

        private static void PickComponentLifetime<T, K, L>(IRegistrationBuilder<T, K, L> registration, CustomAutofacScope? scope)
        {
            switch (scope)
            {
                case null:
                case CustomAutofacScope.PERDEPENDENCY:
                    registration.InstancePerDependency();
                    break;
                case CustomAutofacScope.PERLIFETIMESCOPE:
                    registration.InstancePerLifetimeScope();
                    break;
                case CustomAutofacScope.SINGLE:
                    registration.SingleInstance();
                    break;
                default:
                    throw new InvalidOperationException("No supported lifetime scope found");
            }
        }
    }
}