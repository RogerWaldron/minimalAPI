namespace ArchTests;

public class WebApiLayerTests : BaseTest
{

    [Fact]
    public void WebApi_Should_NotHaveDependencyOnApplication()
    {
        var result = Types.InAssembly(WebApiAssembly)
            .Should()
            .NotHaveDependencyOn("Application")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void WebApi_Should_HaveDependencyOnDataAccess()
    {
        var result = Types.InAssembly(WebApiAssembly)
            .Should()
            .HaveDependencyOn("DataAccess")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}