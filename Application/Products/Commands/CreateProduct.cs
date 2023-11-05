using Domain.Models;
using MediatR;

namespace Application.Products.Commands;

public class CreateProduct : IRequest<Product>
{
    public string? Brand { get; set; }
        
    public string? Title { get; set; }

    public string? Description { get; set; }
}