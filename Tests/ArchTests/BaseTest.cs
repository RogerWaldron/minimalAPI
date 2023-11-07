using System.Reflection;
using Application.Abstractions;
using DataAccess.Repositories;
using Domain.Models;
using WebApi.Config;

namespace ArchTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Product).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IProductRepository).Assembly;
    protected static readonly Assembly WebApiAssembly = typeof(RegisterEndpointsProducts).Assembly;
    protected static readonly Assembly DataAccessAssembly = typeof(ProductRepository).Assembly;
}