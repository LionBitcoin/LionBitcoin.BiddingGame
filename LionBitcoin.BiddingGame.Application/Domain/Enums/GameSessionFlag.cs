namespace LionBitcoin.BiddingGame.Application.Domain.Enums;

[Flags]
public enum GameSessionFlag
{
    TransportCreated = 1,
    PlayersFilled = 2,
}