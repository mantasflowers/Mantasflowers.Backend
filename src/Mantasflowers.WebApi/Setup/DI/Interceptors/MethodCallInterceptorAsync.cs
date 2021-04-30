using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using Serilog;

namespace Mantasflowers.WebApi.Setup.DI.Interceptors
{
    public class MethodCallInterceptorAsync : IAsyncInterceptor
    {
        private readonly ILogger _logger;

        public MethodCallInterceptorAsync(ILogger logger)
        {
            _logger = logger;
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            LogBefore(invocation);

            invocation.Proceed();

            LogAfter(invocation, invocation.ReturnValue);
        }

        public void InterceptAsynchronous(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsync(invocation);
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsync<TResult>(invocation);
        }

        private async Task InternalInterceptAsync(IInvocation invocation)
        {
            LogBefore(invocation);

            invocation.Proceed();
            var task = (Task)invocation.ReturnValue;
            await task;

            LogAfter(invocation, typeof(void).Name);
        }

        private async Task<TResult> InternalInterceptAsync<TResult>(IInvocation invocation)
        {
            LogBefore(invocation);

            invocation.Proceed();
            var task = (Task<TResult>)invocation.ReturnValue;
            TResult result = await task;

            LogAfter(invocation, result);

            return result;
        }

        private void LogBefore(IInvocation invocation)
        {
            _logger.Information("Calling method {methodName} with parameters {parameters}..." + 
                "(User UID: {userUid}; User role: {userRole})",
                $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}",
                JsonConvert.SerializeObject(invocation.Arguments)
            );
        }

        private void LogAfter(IInvocation invocation, object returnValue)
        {
            _logger.Information("Method {methodName} finished with return value: {returnValue}",
                $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}",
                JsonConvert.SerializeObject(returnValue)
            );
        }
    }
}