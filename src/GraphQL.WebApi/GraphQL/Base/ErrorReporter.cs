using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Resolvers;

namespace GraphQL.WebApi.GraphQL.Base
{
    public static class ErrorReporter
    {
        public static void Report(IResolverContext ctx, 
            string errorMessage)
        {
            var error = ErrorBuilder.New()
                .SetMessage(errorMessage)
                .Build();
            ctx.ReportError(error);
        }

        public static void Report(IResolverContext ctx,
            IEnumerable<string> messages)
        {
            var error = ErrorBuilder.New()
                .SetMessage(string.Join(", ", messages))
                .Build();
            ctx.ReportError(error);
        }

        public static void Report(IResolverContext ctx,
            string errorMessage, 
            string code)
        {
            var error = ErrorBuilder.New()
                .SetMessage(errorMessage)
                .SetCode(code)
                .Build();
            ctx.ReportError(error);
        }

        public static void Report(IResolverContext ctx, 
            string errorMessage, 
            Exception ex)
        {
            var error = ErrorBuilder.New()
                .SetMessage(errorMessage)
                .SetException(ex)
                .Build();
            ctx.ReportError(error);
        }
    }
}
