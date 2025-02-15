using LionBitcoin.BiddingGame.Application.Domain.Entities;

namespace LionBitcoin.BiddingGame.Application.Services.Abstractions;

public interface IGameSessionProcessingService
{
    Task PreProcessGameSession(Guid gameSessionId, CancellationToken cancellationToken = default);
}