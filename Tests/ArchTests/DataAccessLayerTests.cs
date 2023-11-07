namespace ArchTests;

public class DataAccessLayerTests : BaseTest
{
    [Fact]
    public void DataAccess_Should_HaveDependencyOnApplicationAndDomain()
    {
        var result = Types.InAssembly(DataAccessAssembly)
            .Should()
            .HaveDependencyOnAll("Application", "Domain")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }    
    
    [Fact]
    public void DataAccess_Should_NotHaveDependencyOnWebApi()
    {
        var result = Types.InAssembly(DataAccessAssembly)
            .Should()
            .NotHaveDependencyOn("WebApi")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }    
    
    [Fact]
    public void DataAccess_Should_HaveDependencyOnDomain()
    {
        var result = Types.InAssembly(DataAccessAssembly)
            .Should()
            .HaveDependencyOn("Domain")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}