using WebApi.Config;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterMyServices();


var app = builder.Build();

app.RegisterMyEndpoints();

app.Run();