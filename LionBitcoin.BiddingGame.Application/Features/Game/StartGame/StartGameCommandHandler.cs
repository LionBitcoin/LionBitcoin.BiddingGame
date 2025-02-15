using System.Data;
using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Domain.Enums;
using LionBitcoin.BiddingGame.Application.Models;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using MediatR;

namespace LionBitcoin.BiddingGame.Application.Features.Game.StartGame;

public class StartGameCommandHandler : IRequestHandler<StartGameCommand, StartGameResponse>
{
    private readonly RequestMetadata _requestMetadata;
    private readonly IUnitOfWork _unitOfWork;

    public StartGameCommandHandler(
        RequestMetadata requestMetadata,
        IUnitOfWork unitOfWork)
    {
        _requestMetadata = requestMetadata;
        _unitOfWork = unitOfWork;
    }

    public async Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
    {
        using IDbTransaction transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

        GameSession gameSession = await GetOrCreateSession(cancellationToken);

        transaction.Commit();
        return new StartGameResponse();
    }

    private async Task<GameSession> GetOrCreateSession(CancellationToken cancellationToken)
    {
        GameSession? gameSession = await _unitOfWork.GameSessionRepository.GetAvailableSession(@lock: true, cancellationToken);
        if (gameSession == null)
        {
            GameSession newSession = new GameSession()
            {
                Id = Guid.CreateVersion7(),
                CreateTimestamp = DateTime.UtcNow,
                UpdateTimestamp = DateTime.UtcNow,
                TicketPrice = 500,
                Currency = Currency.USD,
                PlayersLimit = 10,
                Status = GameSessionStatus.Pending,
                PlayersCount = 1
            };
            await _unitOfWork.GameSessionRepository.Insert(newSession, cancellationToken);
            return newSession;
        }

        return gameSession;
    }
}