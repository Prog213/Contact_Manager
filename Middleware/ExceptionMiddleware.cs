namespace Contact_Manager.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        // Middleware to handle exceptions
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status500InternalServerError;

            var errorMessage = "Internal Server Error" + exception.Message;

            var result = new
            {
                error = errorMessage,
                status = statusCode
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
