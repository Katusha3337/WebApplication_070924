using Humanizer;

namespace WebApplication_070924.Middleware
{
    public class NumberToWordsMiddleware
    {
        readonly RequestDelegate next;
        public NumberToWordsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (int.TryParse(context.Request.Query["number"], out int number))
            {
                string numberInWords = ConvertNumberToWords(number);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"{{\"number\": \"{number}\", \"words\": \"{numberInWords}\"}}");
            }
            else
            {
                await next.Invoke(context);
            }
        }

        private string ConvertNumberToWords(int number)
        {
            return number.ToWords();
        }
    }
}
