namespace WebApplication_070924.Middleware
{
    public class RangeCheckMiddleware
    {
        readonly RequestDelegate next;
        public RangeCheckMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (int.TryParse(context.Request.Query["number"], out int number))
            {
                if (number < 1 || number > 100000)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Number out of range. Please provide a number between 1 and 100000.");
                    return;
                }
                await next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid number format.");
            }
        }
    }
}
