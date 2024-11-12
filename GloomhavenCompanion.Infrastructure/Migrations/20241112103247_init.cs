using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GloomhavenCompanion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsShowingBackCard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsShuffled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenarios_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NeedShuffle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MonsterDeckId = table.Column<int>(type: "int", nullable: false),
                    GameState = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Decks_MonsterDeckId",
                        column: x => x.MonsterDeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HealthPointsMax = table.Column<int>(type: "int", nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampaignScenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    ScenarioId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignScenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignScenarios_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignScenarios_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignScenarios_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "ImagePath", "Name", "State" },
                values: new object[,]
                {
                    { 1, "img/Elements/FirePicture.png", "Feu", 0 },
                    { 2, "img/Elements/DarknessPicture.png", "Ténèbre", 0 },
                    { 3, "img/Elements/EarthPicture.png", "Terre", 0 },
                    { 4, "img/Elements/WindPicture.png", "Vent", 0 },
                    { 5, "img/Elements/LightPicture.png", "Lumière", 0 },
                    { 6, "img/Elements/FrostPicture.png", "Givre", 0 }
                });

            migrationBuilder.InsertData(
                table: "Scenarios",
                columns: new[] { "Id", "CampaignId", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, null, "img/Scenarios/gh-1.png", "Scenario 1" },
                    { 2, null, "img/Scenarios/gh-2.png", "Scenario 2" },
                    { 3, null, "img/Scenarios/gh-3.png", "Scenario 3" },
                    { 4, null, "img/Scenarios/gh-4.png", "Scenario 4" },
                    { 5, null, "img/Scenarios/gh-5.png", "Scenario 5" },
                    { 6, null, "img/Scenarios/gh-6.png", "Scenario 6" },
                    { 7, null, "img/Scenarios/gh-7.png", "Scenario 7" },
                    { 8, null, "img/Scenarios/gh-8.png", "Scenario 8" },
                    { 9, null, "img/Scenarios/gh-9.png", "Scenario 9" },
                    { 10, null, "img/Scenarios/gh-10.png", "Scenario 10" },
                    { 11, null, "img/Scenarios/gh-11-12.png", "Scenario 11" },
                    { 12, null, "img/Scenarios/gh-11-12.png", "Scenario 12" },
                    { 13, null, "img/Scenarios/gh-13.png", "Scenario 13" },
                    { 14, null, "img/Scenarios/gh-14.png", "Scenario 14" },
                    { 15, null, "img/Scenarios/gh-15.png", "Scenario 15" },
                    { 16, null, "img/Scenarios/gh-16.png", "Scenario 16" },
                    { 17, null, "img/Scenarios/gh-17.png", "Scenario 17" },
                    { 18, null, "img/Scenarios/gh-18.png", "Scenario 18" },
                    { 19, null, "img/Scenarios/gh-19.png", "Scenario 19" },
                    { 20, null, "img/Scenarios/gh-20.png", "Scenario 20" },
                    { 21, null, "img/Scenarios/gh-21.png", "Scenario 21" },
                    { 22, null, "img/Scenarios/gh-22.png", "Scenario 22" },
                    { 23, null, "img/Scenarios/gh-23.png", "Scenario 23" },
                    { 24, null, "img/Scenarios/gh-24.png", "Scenario 24" },
                    { 25, null, "img/Scenarios/gh-25.png", "Scenario 25" },
                    { 26, null, "img/Scenarios/gh-26.png", "Scenario 26" },
                    { 27, null, "img/Scenarios/gh-27.png", "Scenario 27" },
                    { 28, null, "img/Scenarios/gh-28.png", "Scenario 28" },
                    { 29, null, "img/Scenarios/gh-29.png", "Scenario 29" },
                    { 30, null, "img/Scenarios/gh-30.png", "Scenario 30" },
                    { 31, null, "img/Scenarios/gh-31.png", "Scenario 31" },
                    { 32, null, "img/Scenarios/gh-32.png", "Scenario 32" },
                    { 33, null, "img/Scenarios/gh-33.png", "Scenario 33" },
                    { 34, null, "img/Scenarios/gh-34.png", "Scenario 34" },
                    { 35, null, "img/Scenarios/gh-35-36.png", "Scenario 35" },
                    { 36, null, "img/Scenarios/gh-35-36.png", "Scenario 36" },
                    { 37, null, "img/Scenarios/gh-37.png", "Scenario 37" },
                    { 38, null, "img/Scenarios/gh-38.png", "Scenario 38" },
                    { 39, null, "img/Scenarios/gh-39.png", "Scenario 39" },
                    { 40, null, "img/Scenarios/gh-40.png", "Scenario 40" },
                    { 41, null, "img/Scenarios/gh-41.png", "Scenario 41" },
                    { 42, null, "img/Scenarios/gh-42.png", "Scenario 42" },
                    { 43, null, "img/Scenarios/gh-43.png", "Scenario 43" },
                    { 44, null, "img/Scenarios/gh-44.png", "Scenario 44" },
                    { 45, null, "img/Scenarios/gh-45.png", "Scenario 45" },
                    { 46, null, "img/Scenarios/gh-46.png", "Scenario 46" },
                    { 47, null, "img/Scenarios/gh-47.png", "Scenario 47" },
                    { 48, null, "img/Scenarios/gh-48.png", "Scenario 48" },
                    { 49, null, "img/Scenarios/gh-49.png", "Scenario 49" },
                    { 50, null, "img/Scenarios/gh-50.png", "Scenario 50" },
                    { 51, null, "img/Scenarios/gh-51.png", "Scenario 51" },
                    { 52, null, "img/Scenarios/gh-52.png", "Scenario 52" },
                    { 53, null, "img/Scenarios/gh-53.png", "Scenario 53" },
                    { 54, null, "img/Scenarios/gh-54.png", "Scenario 54" },
                    { 55, null, "img/Scenarios/gh-55.png", "Scenario 55" },
                    { 56, null, "img/Scenarios/gh-56.png", "Scenario 56" },
                    { 57, null, "img/Scenarios/gh-57.png", "Scenario 57" },
                    { 58, null, "img/Scenarios/gh-58.png", "Scenario 58" },
                    { 59, null, "img/Scenarios/gh-59.png", "Scenario 59" },
                    { 60, null, "img/Scenarios/gh-60.png", "Scenario 60" },
                    { 61, null, "img/Scenarios/gh-61.png", "Scenario 61" },
                    { 62, null, "img/Scenarios/gh-62.png", "Scenario 62" },
                    { 63, null, "img/Scenarios/gh-63.png", "Scenario 63" },
                    { 64, null, "img/Scenarios/gh-64.png", "Scenario 64" },
                    { 65, null, "img/Scenarios/gh-65.png", "Scenario 65" },
                    { 66, null, "img/Scenarios/gh-66.png", "Scenario 66" },
                    { 67, null, "img/Scenarios/gh-67.png", "Scenario 67" },
                    { 68, null, "img/Scenarios/gh-68.png", "Scenario 68" },
                    { 69, null, "img/Scenarios/gh-69.png", "Scenario 69" },
                    { 70, null, "img/Scenarios/gh-70.png", "Scenario 70" },
                    { 71, null, "img/Scenarios/gh-71.png", "Scenario 71" },
                    { 72, null, "img/Scenarios/gh-72.png", "Scenario 72" },
                    { 73, null, "img/Scenarios/gh-73.png", "Scenario 73" },
                    { 74, null, "img/Scenarios/gh-74.png", "Scenario 74" },
                    { 75, null, "img/Scenarios/gh-75.png", "Scenario 75" },
                    { 76, null, "img/Scenarios/gh-76.png", "Scenario 76" },
                    { 77, null, "img/Scenarios/gh-77.png", "Scenario 77" },
                    { 78, null, "img/Scenarios/gh-78.png", "Scenario 78" },
                    { 79, null, "img/Scenarios/gh-79.png", "Scenario 79" },
                    { 80, null, "img/Scenarios/gh-80.png", "Scenario 80" },
                    { 81, null, "img/Scenarios/gh-81.png", "Scenario 81" },
                    { 82, null, "img/Scenarios/gh-82.png", "Scenario 82" },
                    { 83, null, "img/Scenarios/gh-83.png", "Scenario 83" },
                    { 84, null, "img/Scenarios/gh-84.png", "Scenario 84" },
                    { 85, null, "img/Scenarios/gh-85.png", "Scenario 85" },
                    { 86, null, "img/Scenarios/gh-86.png", "Scenario 86" },
                    { 87, null, "img/Scenarios/gh-87.png", "Scenario 87" },
                    { 88, null, "img/Scenarios/gh-88.png", "Scenario 88" },
                    { 89, null, "img/Scenarios/gh-89.png", "Scenario 89" },
                    { 90, null, "img/Scenarios/gh-90.png", "Scenario 90" },
                    { 91, null, "img/Scenarios/gh-91.png", "Scenario 91" },
                    { 92, null, "img/Scenarios/gh-92.png", "Scenario 92" },
                    { 93, null, "img/Scenarios/gh-93.png", "Scenario 93" },
                    { 94, null, "img/Scenarios/gh-94.png", "Scenario 94" },
                    { 95, null, "img/Scenarios/gh-95.png", "Scenario 95" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenarios_CampaignId",
                table: "CampaignScenarios",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenarios_GameId",
                table: "CampaignScenarios",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenarios_ScenarioId",
                table: "CampaignScenarios",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_PlayerId",
                table: "Effects",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_MonsterDeckId",
                table: "Games",
                column: "MonsterDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameId",
                table: "PlayerGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                table: "Players",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DeckId",
                table: "Players",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_GameId",
                table: "Rounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_CampaignId",
                table: "Scenarios",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignScenarios");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
