using System.Reflection;
using LionBitcoin.BiddingGame.Application.Models;
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

        return services;
    }
}