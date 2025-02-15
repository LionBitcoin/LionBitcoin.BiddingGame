using System.Data;
using Dapper;
using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Repositories;
using LionBitcoin.BiddingGame.Persistence.Repositories.Base;

namespace LionBitcoin.BiddingGame.Persistence.Repositories;

public class GameSessionRepository : BaseRepository<GameSession, Guid>, IGameSessionRepository
{
    public GameSessionRepository(BiddingGameDbContext context) : base(context)
    {
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
            sql: @lock ? getAvailableSessionQueryWithLock : getAvailableSessionQuery, 
            transaction: Transaction);
    }

    public Task<List<GameSession>> GetPendingGameSessions(bool @lock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}