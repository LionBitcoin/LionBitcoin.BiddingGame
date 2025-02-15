using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Services.Abstractions;

namespace LionBitcoin.BiddingGame.Application.Services;

public class GameSessionProcessingService : IGameSessionProcessingService
{
    public Task PreProcessGameSession(GameSession gameSession, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}