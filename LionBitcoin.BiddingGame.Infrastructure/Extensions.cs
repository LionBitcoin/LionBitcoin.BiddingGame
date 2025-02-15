using Hangfire;
using Hangfire.PostgreSql;
using LionBitcoin.BiddingGame.Infrastructure.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace LionBitcoin.BiddingGame.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureHangfire(services, configuration);

        return services;
    }

    private static void ConfigureHangfire(IServiceCollection services, IConfiguration configuration)
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

        services.AddHangfire(hangfireConfig => hangfireConfig
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(postgreSqlSettings =>
            {
                postgreSqlSettings.UseNpgsqlConnection(connectionStringBuilder.ConnectionString);
            }));

        services.AddHangfireServer();

        services.AddScoped<GameSessionPreProcessorJob>();
    }

    public static IApplicationBuilder RunHangFire(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard("/hangfire");
        RegisterRecurringJobs(app);

        return app;
    }

    private static void RegisterRecurringJobs(IApplicationBuilder app)
    {
        IRecurringJobManager recurringJobManager = app.ApplicationServices.GetRequiredService<IRecurringJobManager>();
        
        GameSessionPreProcessorJob.RegisterJob(recurringJobManager);
    }
}