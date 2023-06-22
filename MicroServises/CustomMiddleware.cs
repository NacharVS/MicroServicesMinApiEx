namespace MicroServises.UserService
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        string Token { get; set; }
        public CustomMiddleware(RequestDelegate requestDelegate, string token)
        {
            _requestDelegate = requestDelegate;
            Token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["token"] != Token)
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
