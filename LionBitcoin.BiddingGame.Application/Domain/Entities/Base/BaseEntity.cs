namespace LionBitcoin.BiddingGame.Application.Domain.Entities.Base;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; set; }

    public DateTime CreateTimestamp { get; set; }

    public DateTime? UpdateTimestamp { get; set; }
}