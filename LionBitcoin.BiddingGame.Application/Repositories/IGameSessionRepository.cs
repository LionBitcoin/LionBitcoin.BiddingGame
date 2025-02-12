using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Repositories.Base;

namespace LionBitcoin.BiddingGame.Application.Repositories;

public interface IGameSessionRepository : IBaseRepository<GameSession, Guid>
{
    Task<GameSession?> GetAvailableSession(bool @lock, CancellationToken cancellationToken = default);
}