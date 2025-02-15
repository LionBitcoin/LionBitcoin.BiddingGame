using System.Reflection;
using LionBitcoin.BiddingGame.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LionBitcoin.BiddingGame.Persistence;

public class BiddingGameDbContext : DbContext
{
    public DbSet<GameSession> GameSessions { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<GameSessionCustomer> GameSessionCustomers { get; set; }

    public BiddingGameDbContext(DbContextOptions<BiddingGameDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}