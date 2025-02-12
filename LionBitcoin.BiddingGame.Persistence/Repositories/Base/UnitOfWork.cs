using System.Data;
using LionBitcoin.BiddingGame.Application.Repositories;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace LionBitcoin.BiddingGame.Persistence.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly BiddingGameDbContext _dbContext;
    private readonly IGameSessionRepository _gameSessionRepository;

    public UnitOfWork(
        BiddingGameDbContext dbContext,
        IGameSessionRepository gameSessionRepository)
    {
        _dbContext = dbContext;
        _gameSessionRepository = gameSessionRepository;
    }

    public IGameSessionRepository GameSessionRepository => _gameSessionRepository;

    public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        return transaction.GetDbTransaction();
    }
}