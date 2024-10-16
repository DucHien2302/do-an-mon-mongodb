using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.AccessDeniedPath = "/auth/error";
});

builder.Services.AddMvc();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoDBConnection, MongoDBConnection>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
