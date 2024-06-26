using Highfire.Configuration;
using Highfire.Services;
using Highfire.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIoc();

var app = builder.Build();

app.UseRouting();

app.UseMiddleware();

using (var scope = app.Services.CreateScope())
{
    var consumer = scope.ServiceProvider.GetRequiredService<Consumer>();
    consumer.Start();
}

app.MapGet("/", () => "Hello, Hangfire with Dashboard!");

app.Run();