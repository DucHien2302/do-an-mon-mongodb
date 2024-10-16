var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
