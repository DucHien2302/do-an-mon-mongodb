using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.Configure<MongoDBSettings>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
