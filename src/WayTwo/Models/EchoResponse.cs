using System.Security.Claims;

namespace WayTwo.Models;

public class EchoResponse
{
    public string Body { get; set; }
    public string Method { get; set; }
    public PathString Path { get; set; }
    public IQueryCollection Query { get; set; }
    public QueryString QueryString { get; set; }
    public IHeaderDictionary Headers { get; set; }
    public ClaimsPrincipal User { get; set; }
    public string TraceIdentifier { get; set; }
}