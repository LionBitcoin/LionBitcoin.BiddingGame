using LionBitcoin.BiddingGame.Application.Repositories;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using LionBitcoin.BiddingGame.Persistence.Repositories;
using LionBitcoin.BiddingGame.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LionBitcoin.BiddingGame.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BiddingGameDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGameSessionRepository, GameSessionRepository>();

        return services;
    }

    public static void ApplyMigrations(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        BiddingGameDbContext dbContext = scope.ServiceProvider.GetRequiredService<BiddingGameDbContext>();
        dbContext.Database.Migrate();
    }
}