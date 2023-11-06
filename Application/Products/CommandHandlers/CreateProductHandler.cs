using Application.Abstractions;
using Application.Products.Commands;
using Domain.Models;
using MediatR;

namespace Application.Products.CommandHandlers;

public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var newProduct = new Product
        {
            Brand = request.Brand,
            Title = request.Title,
            Description = request.Description
        };

        return await _productRepository.CreateProduct(newProduct);
    }
}