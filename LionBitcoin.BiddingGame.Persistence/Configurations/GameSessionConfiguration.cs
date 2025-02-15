using LionBitcoin.BiddingGame.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LionBitcoin.BiddingGame.Persistence.Configurations;

public class GameSessionConfiguration : IEntityTypeConfiguration<GameSession>
{
    public void Configure(EntityTypeBuilder<GameSession> builder)
    {
        builder.HasKey(gameSession => gameSession.Id);
    }
}