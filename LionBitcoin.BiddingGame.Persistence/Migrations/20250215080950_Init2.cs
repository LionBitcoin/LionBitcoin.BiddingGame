using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LionBitcoin.BiddingGame.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "game_sessions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "game_session_customers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "ix_game_session_customers_customer_id",
                table: "game_session_customers",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_session_customers_game_session_id",
                table: "game_session_customers",
                column: "game_session_id");

            migrationBuilder.AddForeignKey(
                name: "fk_game_session_customers_customers_customer_id",
                table: "game_session_customers",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_game_session_customers_game_sessions_game_session_id",
                table: "game_session_customers",
                column: "game_session_id",
                principalTable: "game_sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_game_session_customers_customers_customer_id",
                table: "game_session_customers");

            migrationBuilder.DropForeignKey(
                name: "fk_game_session_customers_game_sessions_game_session_id",
                table: "game_session_customers");

            migrationBuilder.DropIndex(
                name: "ix_game_session_customers_customer_id",
                table: "game_session_customers");

            migrationBuilder.DropIndex(
                name: "ix_game_session_customers_game_session_id",
                table: "game_session_customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "game_sessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "game_session_customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_timestamp",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
