using WebApi.Config;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();


var app = builder.Build();

app.RegisterEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();