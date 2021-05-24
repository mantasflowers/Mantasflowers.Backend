using System.Net.Http.Headers;

namespace Mantasflowers.WebApi.Extensions
{
    public static class HttpHeadersExtensions
    {
        public static void Add(this HttpHeaders httpHeaders, object source)
        {
            foreach (var property in source.GetType().GetProperties())
            {
                httpHeaders.Add(
                    property.Name,
                    property.GetValue(source, null).ToString()
                    );
            }
        }
    }
}
