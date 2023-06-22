namespace MicroServises.UserService
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CustomMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["token"] != "123")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync($"status code is {context.Response.StatusCode}");
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
        }
    }
}
