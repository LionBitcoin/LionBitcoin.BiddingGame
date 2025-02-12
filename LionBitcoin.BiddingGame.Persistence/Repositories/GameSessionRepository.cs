using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Repositories;

namespace LionBitcoin.BiddingGame.Persistence.Repositories;

public class GameSessionRepository : IGameSessionRepository
{
    private readonly BiddingGameDbContext _context;

    public GameSessionRepository(BiddingGameDbContext context)
    {
        _context = context;
    }

    public Task<Guid> Insert(GameSession entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GameSession> GetById(Guid identifier, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Update(GameSession entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid identifier, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}