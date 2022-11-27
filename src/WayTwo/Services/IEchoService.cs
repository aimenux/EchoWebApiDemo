using WayTwo.Models;

namespace WayTwo.Services;

public interface IEchoService
{
    Task<EchoResponse> GetEchoResponseAsync(CancellationToken cancellationToken = default);
}