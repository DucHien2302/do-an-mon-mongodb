using Microsoft.Extensions.Configuration;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(p =>
{
    p.DefaultAuthenticateScheme = "auth/error"
});

builder.Services.AddMvc();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoDBConnection, MongoDBConnection>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
