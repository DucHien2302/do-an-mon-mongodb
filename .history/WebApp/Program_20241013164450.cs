using Microsoft.Extensions.Configuration;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Configuration.GetSection("MongoDBSettings");

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
