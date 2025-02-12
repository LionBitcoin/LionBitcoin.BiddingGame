using System;
using LionBitcoin.BiddingGame.Application;
using LionBitcoin.BiddingGame.Application.Models;
using LionBitcoin.BiddingGame.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

    public static void ApplyMigrations(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        BiddingGameDbContext dbContext = scope.ServiceProvider.GetRequiredService<BiddingGameDbContext>();
        dbContext.Database.Migrate();
    }
}