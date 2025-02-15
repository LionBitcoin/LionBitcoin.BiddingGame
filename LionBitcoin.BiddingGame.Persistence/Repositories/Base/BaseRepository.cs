using System.Data;
using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LionBitcoin.BiddingGame.Persistence.Repositories.Base;

public abstract class BaseRepository<TEntity, TIdentifier> : IBaseRepository<TEntity, TIdentifier>
    where TIdentifier : struct
    where TEntity : BaseEntity<TIdentifier>
{
    private readonly DbContext _context;

    protected IDbTransaction? Transaction => _context.Database.CurrentTransaction?.GetDbTransaction();
    protected IDbConnection Connection => _context.Database.GetDbConnection();

    public BaseRepository(DbContext context)
    {
        _context = context;
    }
    public Task Insert(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetById(TIdentifier identifier, bool @lock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TIdentifier identifier, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}