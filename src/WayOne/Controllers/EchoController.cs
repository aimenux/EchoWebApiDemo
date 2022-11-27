using Microsoft.AspNetCore.Mvc;
using WayOne.Models;
using WayOne.Services;

namespace WayOne.Controllers;

[ApiController]
[Route("[controller]")]
public class EchoController : ControllerBase
{
    private readonly IEchoService _service;
    private readonly ILogger<EchoController> _logger;

    public EchoController(IEchoService echoService, ILogger<EchoController> echoLogger)
    {
        _service = echoService ?? throw new ArgumentNullException(nameof(echoService));
        _logger = echoLogger ?? throw new ArgumentNullException(nameof(echoLogger));
    }

    [HttpGet(Name = "GetEchoResponse")]
    public async Task<EchoResponse> GetEchoResponseAsync(CancellationToken cancellationToken = default)
    {
        var response = await _service.GetEchoResponseAsync(cancellationToken);
        _logger.LogTrace("Response is {@response}", response);
        return response;
    }
}