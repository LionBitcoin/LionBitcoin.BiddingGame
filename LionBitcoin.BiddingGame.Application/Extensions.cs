using System.Reflection;
using LionBitcoin.BiddingGame.Application.Models;
using LionBitcoin.BiddingGame.Application.Services;
using LionBitcoin.BiddingGame.Application.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LionBitcoin.BiddingGame.Application;

public static class Reference
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<RequestMetadata>();
        services.AddScoped<IGameSessionProcessorService, GameSessionProcessorService>();

        return services;
    }
}