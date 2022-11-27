using FluentAssertions;
using System.Net;

namespace WayOneTests;

public class IntegrationTests
{
    [Fact]
    public async Task ShouldGetEchoResponse()
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("/echo");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}