using LionBitcoin.BiddingGame.Application;
using LionBitcoin.BiddingGame.Application.Shared;
using LionBitcoin.BiddingGame.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LionBitcoin.BiddingGame;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<Reference>();
        });

        services.AddScoped<RequestMetadata>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BiddingGameDbContext>();
        return services;
    }
}