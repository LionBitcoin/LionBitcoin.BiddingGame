using LionBitcoin.BiddingGame.Application.Domain.Entities;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using LionBitcoin.BiddingGame.Application.Services.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LionBitcoin.BiddingGame.Application.Features.Game.PreProcessGameSessions;

public class PreProcessGameSessionsCommandHandler : IRequestHandler<PreProcessGameSessionsCommand, PreProcessGameSessionsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PreProcessGameSessionsCommandHandler(IUnitOfWork unitOfWork, IServiceScopeFactory serviceScopeFactory)
    {
        _unitOfWork = unitOfWork;
        _serviceScopeFactory = serviceScopeFactory;
    }
    public async Task<PreProcessGameSessionsResponse> Handle(PreProcessGameSessionsCommand request, CancellationToken cancellationToken)
    {
        List<GameSession> gameSessions = await _unitOfWork.GameSessionRepository.GetPendingGameSessions(
            @lock: false, cancellationToken);
    
        if (gameSessions.Count == 0) return new PreProcessGameSessionsResponse();

        ParallelOptions options = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 10,
            CancellationToken = cancellationToken
        };

        await Parallel.ForEachAsync(
            gameSessions,
            options,
            PreProcessGameSession);

        return new PreProcessGameSessionsResponse();
    }

    private async ValueTask PreProcessGameSession(GameSession gameSession, CancellationToken token)
    {
        try
        {
            IServiceScope serviceScope = _serviceScopeFactory.CreateScope();
            IGameSessionProcessingService processor =
                serviceScope.ServiceProvider.GetRequiredService<IGameSessionProcessingService>();
            await processor.PreProcessGameSession(gameSession.Id, token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);//TODO: change to logging
        }
    }
}