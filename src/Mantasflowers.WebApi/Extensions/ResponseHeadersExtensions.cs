using System;
using Microsoft.AspNetCore.Http;

namespace Mantasflowers.WebApi.Extensions
{
    public static class ResponseHeadersExtensions
    {
        public static void AddETagHeader(this IHeaderDictionary headers, byte[] value)
        {
            headers.Add("etag", Convert.ToBase64String(value));
        }
    }
}