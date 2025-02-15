using System.Reflection;
using LionBitcoin.BiddingGame.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace LionBitcoin.BiddingGame.Persistence;

public class BiddingGameDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<GameSession> GameSessions { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<GameSessionCustomer> GameSessionCustomers { get; set; }

    public BiddingGameDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        PostgresDbSettings postgresDbSettings = new PostgresDbSettings();
        _configuration.GetSection(nameof(PostgresDbSettings)).Bind(postgresDbSettings);

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

        optionsBuilder.UseNpgsql(connectionStringBuilder.ConnectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}