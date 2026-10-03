namespace StockPortfolioBFF.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        public readonly RequestDelegate _next;

        public ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UnHandled Excpetion Occured");
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";

                var response = new { message = "Internal Server Error" };
                await httpContext.Response.WriteAsJsonAsync(response);
            }


        }
    }
}
