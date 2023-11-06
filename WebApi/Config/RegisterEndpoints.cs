using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Models;
using MediatR;

namespace WebApi.Config
{
    public static class RegisterEndpoints
    {
        public static void RegisterMyEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/api/products/{id}", async (IMediator m, int id) =>
            {
                var getProduct = new GetProductById { ProductId = id};
                var result = await m.Send(getProduct);

                return Results.Ok(result);
            }).WithName("GetProductById");

            app.MapGet("/api/products", async (IMediator m) =>
            {
                var req = new GetAllProducts();
                var products = await m.Send(req);

                return Results.Ok(products);
            });

            app.MapPost("/api/products", async (IMediator m, Product product) =>
            {
                var createProduct = new CreateProduct
                {
                    Brand = product.Brand, Title = product.Title, Description = product.Description
                };
                var newProduct = await m.Send(createProduct);

                return Results.CreatedAtRoute("GetProductById", new { newProduct.Id }, newProduct);
            });

            app.MapPut("/api/products/{id}", async (IMediator m, Product product, int id) =>
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

            app.MapDelete("/api/products/{id}", async (IMediator m, int id) =>
            {
                var delete = new DeleteProduct { ProductId = id };
                await m.Send(delete);

                return Results.NoContent();
            });
        }
    }
}
