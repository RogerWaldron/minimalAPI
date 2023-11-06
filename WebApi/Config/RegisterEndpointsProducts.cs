using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Models;
using MediatR;

namespace WebApi.Config
{
    public static class RegisterEndpointsProducts
    {
        public static void RegisterProductsApiEndpoints(this WebApplication app)
        {
            var groupUrl = app.MapGroup("/api/products");
            
            groupUrl.MapGet("/{id}", async (IMediator m, int id) =>
            {
                var getProduct = new GetProductById { ProductId = id};
                var result = await m.Send(getProduct);

                return Results.Ok(result);
            }).WithName("GetProductById");

            groupUrl.MapGet("/", async (IMediator m) =>
            {
                var req = new GetAllProducts();
                var products = await m.Send(req);
                
                return Results.Ok(products);
            });

            groupUrl.MapPost("/", async (IMediator m, Product product) =>
            {
                var createProduct = new CreateProduct
                {
                    Brand = product.Brand, Title = product.Title, Description = product.Description
                };
                var newProduct = await m.Send(createProduct);

                return Results.CreatedAtRoute("GetProductById", new { newProduct.Id }, newProduct);
            });

            groupUrl.MapPut("/{id}", async (IMediator m, Product product, int id) =>
            {
                var update = new UpdateProduct
                {
                    ProductId = id,
                    Brand = product.Brand,
                    Title = product.Title,
                    Description = product.Description
                };
                var updatedProduct = await m.Send(update);

                return Results.Ok(updatedProduct);
            });

            groupUrl.MapDelete("/{id}", async (IMediator m, int id) =>
            {
                var delete = new DeleteProduct { ProductId = id };
                await m.Send(delete);

                return Results.NoContent();
            });
        }
    }
}
