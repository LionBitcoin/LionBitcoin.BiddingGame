using LionBitcoin.BiddingGame.Application.Features.Game.PreProcessGameSessions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LionBitcoin.BiddingGame.Infrastructure.HostedServices;

public class GameSessionPreProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GameSessionPreProcessor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CallGameSessionPreProcessing(stoppingToken);
        }
    }

    private async Task CallGameSessionPreProcessing(CancellationToken stoppingToken)
    {
        try
        {
            IMediator mediator = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IMediator>();
            await mediator.Send(new PreProcessGameSessionsCommand(), stoppingToken);
        }
        catch (Exception ex)
        {
            // TODO: Logging
        }
        finally
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}