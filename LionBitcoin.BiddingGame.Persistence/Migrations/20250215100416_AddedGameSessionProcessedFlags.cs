using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LionBitcoin.BiddingGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedGameSessionProcessedFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "flags",
                table: "game_sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flags",
                table: "game_sessions");
        }
    }
}
