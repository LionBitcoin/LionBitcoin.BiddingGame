using LionBitcoin.BiddingGame.Infrastructure.HostedServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LionBitcoin.BiddingGame.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<GameSessionPreProcessor>();
        return services;
    }
}