using LionBitcoin.BiddingGame.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LionBitcoin.BiddingGame.Persistence.Configurations;

public class GameSessionCustomerConfiguration : IEntityTypeConfiguration<GameSessionCustomer>
{
    public void Configure(EntityTypeBuilder<GameSessionCustomer> builder)
    {
        builder.HasKey(gameSessionCustomer => gameSessionCustomer.Id);

        builder
            .HasOne<GameSession>()
            .WithMany()
            .HasForeignKey(gameSessionCustomer => gameSessionCustomer.GameSessionId);

        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(gameSessionCustomer => gameSessionCustomer.CustomerId);
    }
}