using GraphQL.WebApi.GraphQL.Base;
using GraphQL.WebApi.GraphQL.Interceptors;
using GraphQL.WebApi.GraphQL.Mutations;
using GraphQL.WebApi.GraphQL.Querys;
using GraphQL.WebApi.GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.WebApi.GraphQL.Extensions
{
    public static class ServiceCollectionGraphQLExtension
    {
        public static IServiceCollection AddCustomGraphQL(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddGraphQLServer()
                .AddIntrospectionAllowedRule()
                .AddHttpRequestInterceptor(_ => new ConditionalIntrospectionHttpRequestInterceptor(configuration))
                .AddAuthorization()
                .AddSorting()
                .AddFiltering()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<BookQuery>()
                .AddTypeExtension<BookMutation>()
                .AddType<BookType>();

            return services;
        }
    }
}
