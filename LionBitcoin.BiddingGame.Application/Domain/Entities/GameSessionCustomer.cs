using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;

namespace LionBitcoin.BiddingGame.Application.Domain.Entities;

/// <summary>
/// Mapping between GameSessions and Customers
/// </summary>
public class GameSessionCustomer : BaseEntity<int>
{
    public Guid GameSessionId { get; set; }

    public Guid CustomerId { get; set; }
}