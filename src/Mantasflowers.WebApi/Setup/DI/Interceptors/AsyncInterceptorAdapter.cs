using Castle.DynamicProxy;

namespace Mantasflowers.WebApi.Setup.DI.Interceptors
{
    /// <summary>
    /// Adapter class that allows registering <see cref="IAsyncInterceptor"/> instances
    /// as <see cref="IInterceptor"/> for Autofac.
    /// </summary>
    ///
    public class AsyncInterceptorAdapter<TAsyncInterceptor> : AsyncDeterminationInterceptor
        where TAsyncInterceptor : IAsyncInterceptor
    {
        public AsyncInterceptorAdapter(TAsyncInterceptor asyncInterceptor)
            : base(asyncInterceptor) { }
    }
}