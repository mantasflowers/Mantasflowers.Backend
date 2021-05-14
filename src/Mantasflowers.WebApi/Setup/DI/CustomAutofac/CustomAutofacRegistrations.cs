using System.Collections.Generic;

namespace Mantasflowers.WebApi.Setup.DI.CustomAutofac
{
    internal class CustomAutofacRegistrations
    {
        public ICollection<CustomAutofacComponent> Components { get; set; }
    }

    internal class CustomAutofacType
    {
        public string Type { get; set; }
    }

    internal class CustomAutofacComponent : CustomAutofacType
    {
        public ICollection<CustomAutofacInterface> Interfaces { get; set; }

        public ICollection<CustomAutofacInterceptor> Interceptors { get; set; }

        public CustomAutofacScope? Scope { get; set; }
    }

    internal class CustomAutofacInterface : CustomAutofacType
    {
    }

    internal class CustomAutofacInterceptor : CustomAutofacType
    {
    }

    internal enum CustomAutofacScope
    {
        PERDEPENDENCY,
        PERLIFETIMESCOPE,
        SINGLE
    }
}