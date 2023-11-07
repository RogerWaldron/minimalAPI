namespace ArchTests;

public class WebApiLayerTests : BaseTest
{
    [Fact]
    public void WebApi_Should_HaveDependencyOnDataAccess()
    {
        var result = Types.InAssembly(WebapiAssembly)
            .Should()
            .NotHaveDependencyOn("DataAccess")
            .GetResult();

        result.IsSuccessful.Should().BeFalse();
    }    
}