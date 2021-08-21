using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GraphQL.WebApi.GraphQL.Interceptors
{
    public class ConditionalIntrospectionHttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        private readonly IConfiguration _configuration;

        public ConditionalIntrospectionHttpRequestInterceptor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override async ValueTask OnCreateAsync(HttpContext context,
            IRequestExecutor requestExecutor,
            IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken)
        {
            string header = context.Request.Headers["X-INTROSPECTION-QUERY"];
            var key = _configuration["IntrospectionKey"];

            if (header != null &&
                key != null &&
                header.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                requestBuilder.AllowIntrospection();
            else
                requestBuilder.SetIntrospectionNotAllowedMessage($"The introspection query has been disabled.");

            await base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }
    }
}
