using Microsoft.AspNetCore.Mvc;
using WebApplication_070924;
using WebApplication_070924.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<NumberDeterminantMiddleware>();
app.UseMiddleware<RangeCheckMiddleware>();
app.UseMiddleware<NumberToWordsMiddleware>();
app.UseMiddleware<SentenceLengthMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();


//app.Environment.EnvironmentName = "Production";

//if (app.Environment.IsDevelopment())
//{
//    app.Run(async(context) => await context.Response.WriteAsync("In Development Stage"));
//}
//else if(app.Environment.IsProduction())
//{
//    app.Run(async (context) => await context.Response.WriteAsync("In Production Stage"));
//}
//else if (app.Environment.IsEnvironment("Testing"))
//{
//    app.Run(async (context) => await context.Response.WriteAsync("In Testing Stage"));
//}

app.Run();
