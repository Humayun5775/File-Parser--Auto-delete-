var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWindowsService();
builder.Services.AddWindowsService();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
