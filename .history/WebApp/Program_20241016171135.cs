using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebApp;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.ExpireTimeSpan = TimeSpan.FromDays(10);
    p.AccessDeniedPath = "/auth/error";
});

builder.Services.AddMvc();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddSingleton<IMongoDBConnection, MongoDBConnection>();
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
