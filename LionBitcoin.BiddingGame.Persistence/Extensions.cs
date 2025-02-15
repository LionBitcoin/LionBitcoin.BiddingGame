using LionBitcoin.BiddingGame.Application.Repositories;
using LionBitcoin.BiddingGame.Application.Repositories.Base;
using LionBitcoin.BiddingGame.Persistence.Repositories;
using LionBitcoin.BiddingGame.Persistence.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace LionBitcoin.BiddingGame.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureDbContext(services, configuration);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGameSessionRepository, GameSessionRepository>();

        return services;
    }

    private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BiddingGameDbContext>(options =>
        {
            PostgresDbSettings postgresDbSettings = new PostgresDbSettings();
            configuration.GetSection(nameof(PostgresDbSettings)).Bind(postgresDbSettings);

            NpgsqlConnectionStringBuilder connectionStringBuilder = new NpgsqlConnectionStringBuilder()
            {
                Host = postgresDbSettings.Host,
                Port = postgresDbSettings.Port,
                Database = postgresDbSettings.Database,
                Username = postgresDbSettings.Username,
                Password = postgresDbSettings.Password,
                MaxPoolSize = postgresDbSettings.MaxPoolSize,
                Pooling = true
            };

            options.UseNpgsql(connectionStringBuilder.ConnectionString);
            options.UseSnakeCaseNamingConvention();
        });
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        BiddingGameDbContext dbContext = scope.ServiceProvider.GetRequiredService<BiddingGameDbContext>();
        dbContext.Database.Migrate();
    }
}