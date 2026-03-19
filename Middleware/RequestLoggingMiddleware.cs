namespace MyUserApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log before moving to the next middleware
            Console.WriteLine($"[LOG] {DateTime.Now}: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // Log after the response is sent
            Console.WriteLine($"[LOG] Response Status: {context.Response.StatusCode}");
        }
    }
}
