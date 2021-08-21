using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Client.WebApi.DTO;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Client.WebApi.Extensions
{
    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly IOptions<AzureAdConfig> _config;

        public AuthorizationHandler(IOptions<AzureAdConfig> config, HttpMessageHandler inner = null) 
            : base(inner ?? new HttpClientHandler())
        {
            _config = config;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            var app = ConfidentialClientApplicationBuilder.Create(_config.Value.ClientId)
                .WithClientSecret(_config.Value.ClientSecret)
                .WithAuthority(new Uri(_config.Value.Authority))
                .Build();

            var token = await app.AcquireTokenForClient(_config.Value.Scopes)
                .ExecuteAsync(cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
