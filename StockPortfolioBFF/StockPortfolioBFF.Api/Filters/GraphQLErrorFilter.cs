using HotChocolate.Execution;

namespace StockPortfolioBFF.Api.Filters
{
    // Hot Chocolate handles resolver exceptions as GraphQL errors, so they do not
    // reach the ASP.NET Core exception middleware. Log and sanitize them here.
    public sealed class GraphQLErrorFilter : IErrorFilter
    {
        private readonly ILogger<GraphQLErrorFilter> _logger;

        public GraphQLErrorFilter(ILogger<GraphQLErrorFilter> logger)
        {
            _logger = logger;
        }
        public IError OnError(IError error)
        {
            if (error.Exception is { } exception)
            {
                _logger.LogError(exception, "UnHandled GraphQL resolver error at path {path}",error.Path);
               
                return error
                .WithMessage("An unexpected error occurred.")
                .WithCode("INTERNAL_SERVER_ERROR");
            }


            // Return the error as-is; modify here if you need to filter/transform it.
            return error;
        }
    }
}
