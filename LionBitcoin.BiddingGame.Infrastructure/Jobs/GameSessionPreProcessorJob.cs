using Hangfire;
using LionBitcoin.BiddingGame.Application.Features.Game.PreProcessGameSessions;
using MediatR;

namespace LionBitcoin.BiddingGame.Infrastructure.Jobs;

public class GameSessionPreProcessorJob
{
    private readonly IMediator _mediator;

    public GameSessionPreProcessorJob(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task InitiatePreProcessingForGameSessions()
    {
        await _mediator.Send(new PreProcessGameSessionsCommand());
    }

    public static void RegisterJob(IRecurringJobManager recurringJobManager)
    {
        recurringJobManager.AddOrUpdate<GameSessionPreProcessorJob>(
            recurringJobId: nameof(GameSessionPreProcessorJob), 
            methodCall: job => job.InitiatePreProcessingForGameSessions(), 
            cronExpression: Cron.Minutely());
    }
}