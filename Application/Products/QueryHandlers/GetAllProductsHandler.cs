using Application.Abstractions;
using Application.Products.Queries;
using Domain.Models;
using MediatR;

namespace Application.Products.QueryHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ICollection<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllProducts();
    }
}