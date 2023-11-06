using Domain.Models;
using MediatR;

namespace Application.Products.Queries;

public class GetAllProducts : IRequest<ICollection<Product>>
{
    
}