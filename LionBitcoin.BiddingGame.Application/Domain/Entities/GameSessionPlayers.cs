using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;

namespace LionBitcoin.BiddingGame.Application.Domain.Entities;

public class GameSessionPlayers : BaseEntity<int>
{
    public Guid GameSessionId { get; set; }

    public Guid CustomerId { get; set; }
}