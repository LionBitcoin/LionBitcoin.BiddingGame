using LionBitcoin.BiddingGame.Application.Domain.Entities.Base;
using LionBitcoin.BiddingGame.Application.Domain.Enums;

namespace LionBitcoin.BiddingGame.Application.Domain.Entities;

public class GameSession : BaseEntity<Guid>
{
    public int PlayersLimit { get; set; }

    public GameSessionStatus Status { get; set; }
    
    public int PlayersCount { get; set; }

    /// <summary>
    /// Ticket price is in the smallest unit. if prices are calculated in USD, then smallest unit is cent. if it is calculated in GEL, then smallest unit is TETRI
    /// </summary>
    public ulong TicketPrice { get; set; }
}