var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
