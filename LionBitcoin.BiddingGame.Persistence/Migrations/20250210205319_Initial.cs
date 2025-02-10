using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LionBitcoin.BiddingGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_session_players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    game_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_session_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    players_limit = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    players_count = table.Column<int>(type: "integer", nullable: false),
                    ticket_price = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    create_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_sessions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "game_session_players");

            migrationBuilder.DropTable(
                name: "game_sessions");
        }
    }
}
