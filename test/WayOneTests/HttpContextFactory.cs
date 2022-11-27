using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace WayOneTests;

public class HttpContextFactory
{
    public static HttpContext Create()
    {
        var json = JsonSerializer.Serialize(new
        {
            Id = Guid.NewGuid().ToString("D")
        });
        var context = new DefaultHttpContext();
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        context.Request.Body = stream;
        context.Request.ContentLength = stream.Length;
        context.Request.ContentType = "application/json";
        return context;
    }
}