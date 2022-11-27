using WayTwo.Models;

namespace WayTwo.Services;

public class EchoService : IEchoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EchoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public async Task<EchoResponse> GetEchoResponseAsync(CancellationToken cancellationToken)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null) return null;
        var httpRequest = httpContext.Request;
        var body = await GetBodyStringAsync(httpRequest);
        var echoResponse = new EchoResponse
        {
            Body = body,
            User = httpContext.User,
            Path = httpRequest.Path,
            Query = httpRequest.Query,
            Method = httpRequest.Method,
            Headers = httpRequest.Headers,
            QueryString = httpRequest.QueryString,
            TraceIdentifier = httpContext.TraceIdentifier
        };
        return echoResponse;
    }

    private static async Task<string> GetBodyStringAsync(HttpRequest httpRequest)
    {
        using var streamReader = new StreamReader(httpRequest.Body);
        return await streamReader.ReadToEndAsync();
    }
}