using System.Data;
using Dapper;
using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LionBitcoin.BiddingGame.Persistence.Repositories;

public class GameSessionRepository : IGameSessionRepository
{
    private readonly BiddingGameDbContext _context;
    private IDbTransaction? Transaction => _context.Database.CurrentTransaction?.GetDbTransaction();
    private IDbConnection Connection => _context.Database.GetDbConnection();

    public GameSessionRepository(BiddingGameDbContext context)
    {
        _context = context;
    }

    public Task Insert(GameSession entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GameSession> GetById(Guid identifier, bool @lock, CancellationToken cancellationToken = default)
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

    public Task<GameSession?> GetAvailableSession(bool @lock, CancellationToken cancellationToken = default)
    {
        const string getAvailableSessionQueryWithLock = @"SELECT
                                                              *
                                                          FROM game_sessions 
                                                              ORDER BY create_timestamp DESC
                                                          LIMIT 1 FOR UPDATE;";
        const string getAvailableSessionQuery = @"SELECT
                                                      *
                                                  FROM game_sessions 
                                                      ORDER BY create_timestamp DESC
                                                  LIMIT 1;";

        return Connection.QuerySingleOrDefaultAsync<GameSession>(
            @lock ? getAvailableSessionQueryWithLock : getAvailableSessionQuery, 
            Transaction);
    }
}