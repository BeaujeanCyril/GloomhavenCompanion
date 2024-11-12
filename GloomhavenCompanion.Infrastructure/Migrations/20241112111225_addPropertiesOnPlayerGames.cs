using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GloomhavenCompanion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPropertiesOnPlayerGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coins",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HealthPoints",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HealthPointsMax",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "PlayerGames",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "PlayerGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGameGameId",
                table: "Effects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerGamePlayerId",
                table: "Effects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Effects_PlayerGamePlayerId_PlayerGameGameId",
                table: "Effects",
                columns: new[] { "PlayerGamePlayerId", "PlayerGameGameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_PlayerGames_PlayerGamePlayerId_PlayerGameGameId",
                table: "Effects",
                columns: new[] { "PlayerGamePlayerId", "PlayerGameGameId" },
                principalTable: "PlayerGames",
                principalColumns: new[] { "PlayerId", "GameId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Effects_PlayerGames_PlayerGamePlayerId_PlayerGameGameId",
                table: "Effects");

            migrationBuilder.DropIndex(
                name: "IX_Effects_PlayerGamePlayerId_PlayerGameGameId",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "Coins",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "HealthPoints",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "HealthPointsMax",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "PlayerGames");

            migrationBuilder.DropColumn(
                name: "PlayerGameGameId",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "PlayerGamePlayerId",
                table: "Effects");
        }
    }
}
