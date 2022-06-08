using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RandomNumberService>();

var app = builder.Build();

app.UseHttpLogging();

app.Use(async (context, next) =>
{
    Console.WriteLine(context.GetEndpoint()?.DisplayName ?? "null");

    await next(context);

});

app.UseRouting();

app.Use(async (context, next) =>
{
    Console.WriteLine(context.GetEndpoint()?.DisplayName ?? "null");

    await next(context);

});

app.MapGet("/", () => "Hello World!");


//app.UseEndpoints(x =>
//{
//    x.MapGet("/", () => "Hello World!");

//});


app.Run();
