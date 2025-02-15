using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Domain.Enums;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using LionBitcoin.BiddingGame.Application.Services.Abstractions;

namespace LionBitcoin.BiddingGame.Application.Services;

public class GameSessionProcessingService : IGameSessionProcessingService
{
    private readonly IUnitOfWork _unitOfWork;

    public GameSessionProcessingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// This Method is called in background, because it is designed to preprocess game session asynchronously.
    /// </summary>
    public async Task PreProcessGameSession(Guid gameSessionId, CancellationToken cancellationToken = default)
    {
        GameSession gameSession = await _unitOfWork.GameSessionRepository.GetById(gameSessionId, false, cancellationToken);

        await HandleTransportCreation(gameSession);
        await HandleTransportListenersCreation(gameSession);
        await HandlePlayersCountCheck(gameSession);
        await TryToActivateGameSession(gameSession);
    }

    /// <summary>
    /// Tries to activate game. it means that preprocessing is done, so we can start game processing.
    /// game processing means that we are listening to users actions through transport
    /// </summary>
    private async Task TryToActivateGameSession(GameSession gameSession)
    {
        if (!gameSession.Flags.HasFlag(
                GameSessionFlag.TransportListenersCreated |
                GameSessionFlag.PlayersFilled |
                GameSessionFlag.TransportCreated)) return;
    
        
    }

    private async Task HandleTransportCreation(GameSession gameSession)
    {
        if (gameSession.Flags.HasFlag(GameSessionFlag.TransportCreated)) return;
    }

    private async Task HandleTransportListenersCreation(GameSession gameSession)
    {
        if (gameSession.Flags.HasFlag(GameSessionFlag.TransportListenersCreated)) return;
    }

    private async Task HandlePlayersCountCheck(GameSession gameSession)
    {
        if (gameSession.Flags.HasFlag(GameSessionFlag.PlayersFilled)) return;
    }
}