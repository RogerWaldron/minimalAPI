using Asp.Versioning;
using WebApi.Config;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opts =>
{
    opts.DefaultApiVersion = new ApiVersion(1.0);
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;
}).EnableApiVersionBinding();

builder.Services.AddSwaggerGen();

builder.RegisterMyServices();


var app = builder.Build();

app.RegisterProductsApiEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();