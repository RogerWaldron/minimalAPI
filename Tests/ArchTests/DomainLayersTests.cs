namespace ArchTests;

public class DomainLayerTests : BaseTest
{
    [Fact]
    public void Domain_Should_NotHaveDependencyOnAnyLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOnAny("Application, DataAccess, WebApi")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}