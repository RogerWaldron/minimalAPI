using Domain.Models;
using MediatR;

namespace Application.Products.Commands;

public class UpdateProduct : IRequest<Product>
{
    public int ProductId { get; set; }

    public string? Brand { get; set; }
        
    public string? Title { get; set; }

    public string? Description { get; set; }
}