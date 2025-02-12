using System.Data;

namespace LionBitcoin.BiddingGame.Application.Repositories.Base;

public interface IUnitOfWork
{
    IGameSessionRepository GameSessionRepository { get; }

    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}