using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;

namespace LionBitcoin.BiddingGame.Application.Repositories.Base;

public interface IBaseRepository<TEntity, TIdentifier>
    where TIdentifier : struct
    where TEntity : BaseEntity<TIdentifier>
{
    Task<TIdentifier> Insert(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetById(TIdentifier identifier, CancellationToken cancellationToken = default);

    Task Update(TEntity entity, CancellationToken cancellationToken = default);

    Task Delete(TIdentifier identifier, CancellationToken cancellationToken = default);
}