using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;

namespace LionBitcoin.BiddingGame.Application.Repositories.Base;

public interface IBaseRepository<TEntity, in TIdentifier>
    where TIdentifier : struct
    where TEntity : BaseEntity<TIdentifier>
{
    Task Insert(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetById(TIdentifier identifier, bool @lock, CancellationToken cancellationToken = default);

    Task Update(TEntity entity, CancellationToken cancellationToken = default);

    Task Delete(TIdentifier identifier, CancellationToken cancellationToken = default);
}