using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using WayTwo.Services;

namespace WayTwoTests;

public class UnitTests
{
    [Fact]
    public async Task ShouldGetEchoResponse()
    {
        // arrange
        var accessor = Substitute.For<IHttpContextAccessor>();
        accessor.HttpContext.Returns(HttpContextFactory.Create());
        var service = new EchoService(accessor);

        // act
        var response = await service.GetEchoResponseAsync(CancellationToken.None);

        // assert
        response.Should().NotBeNull();
        response.Body.Should().NotBeNull();
        response.Headers.Should().NotBeNull();
        response.Method.Should().NotBeNull();
        response.Path.Should().NotBeNull();
        response.Query.Should().NotBeNull();
        response.QueryString.Should().NotBeNull();
        response.TraceIdentifier.Should().NotBeNull();
        response.User.Should().NotBeNull();
    }
}