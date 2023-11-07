namespace ArchTests;

public class ApplicationLayerTests : BaseTest
{
    [Fact]
    public void Application_ShouldHaveDependencyOnDomain()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .HaveDependencyOn("Domain")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Application_ShouldOnlyHaveDependencyOnDomain()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOnAny("WebApi, DataAccess")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}