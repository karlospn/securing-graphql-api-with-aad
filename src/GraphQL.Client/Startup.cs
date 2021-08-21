using System;
using Client.WebApi.DTO;
using Client.WebApi.Extensions;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Client.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL.Client", Version = "v1" });
            });

            services.AddScoped<IGraphQLClient>(sp =>
                new GraphQLHttpClient(new GraphQLHttpClientOptions
                    {
                        EndPoint = new Uri(Configuration["GraphQLURI"]),
                        HttpMessageHandler = new AuthorizationHandler(sp.GetRequiredService<IOptions<AzureAdConfig>>()),

                    }, new SystemTextJsonSerializer())
            );

            services.AddOptions<AzureAdConfig>()
                .Bind(Configuration.GetSection("AzureAd"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL.Client v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
