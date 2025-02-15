namespace LionBitcoin.BiddingGame.Application.Services.Abstractions;

public interface IGameSessionProcessorService
{
    Task PreProcessGameSession(Guid gameSessionId);
}