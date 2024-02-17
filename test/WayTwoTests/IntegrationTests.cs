using System.Net;
using FluentAssertions;

namespace WayTwoTests;

public class IntegrationTests
{
    [Fact]
    public async Task ShouldGetEchoResponse()
    {
        // arrange
        var factory = new ApiWebApplicationFactory();
        var client = factory.CreateClient();

        // act
        var response = await client.GetAsync("/echo");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}