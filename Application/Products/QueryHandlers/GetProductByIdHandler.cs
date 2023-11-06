using Application.Abstractions;
using Application.Products.Queries;
using Domain.Models;
using MediatR;

namespace Application.Products.QueryHandlers;

public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductById(request.ProductId);
    }
}