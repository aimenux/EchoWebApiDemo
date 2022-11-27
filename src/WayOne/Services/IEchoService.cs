using WayOne.Models;

namespace WayOne.Services;

public interface IEchoService
{
    Task<EchoResponse> GetEchoResponseAsync(CancellationToken cancellationToken = default);
}