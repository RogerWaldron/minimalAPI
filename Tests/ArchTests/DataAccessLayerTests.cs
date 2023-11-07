namespace ArchTests;

public class DataAccessLayerTests : BaseTest
{
    [Fact]
    public void DataAccess_Should_NotHaveDependencyOnWebApi()
    {
        var result = Types.InAssembly(DataAccessAssembly)
            .Should()
            .NotHaveDependencyOn("WebApi")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }    
}