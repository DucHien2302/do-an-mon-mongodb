using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.Get("MongoDB"));

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();